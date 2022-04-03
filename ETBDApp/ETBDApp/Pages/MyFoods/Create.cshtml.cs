namespace ETBDApp.Pages.MyFoods
{
    public class CreateModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public CreateModel(ETBDDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            this.Categories = new SelectList(_context.Categories, "Id", "Name");
            this.Actions = _context.Actions;

            return Page();
        }

        [BindProperty]
        public Food Food { get; set; }

        public SelectList Categories { get; set; }

        [BindProperty]
        public int SelectedCategoryId { get; set; }


        public IEnumerable<Action> Actions { get; set; }

        [BindProperty]
        public IEnumerable<int> SelectedActionsId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (SelectedActionsId == null || !SelectedActionsId.Any())
            {
                ViewData["Message"] = "You need to select at least one action!";

                this.Categories = new SelectList(_context.Categories, "Id", "Name");

                this.Actions = _context.Actions; 

                return Page();
            }
            Food.Category = _context.Categories.FirstOrDefault(c => c.Id == SelectedCategoryId);

            ModelState.Clear();
            TryValidateModel(Food);

            if (!ModelState.IsValid)
            {
                this.Categories = new SelectList(_context.Categories, "Id", "Name");
                return Page();
            }

            _context.Foods.Add(Food);

            await _context.SaveChangesAsync();

            await AddActionsToFoodAsync();

            return RedirectToPage("./Index");
        }

        private async Task AddActionsToFoodAsync()
        {
            foreach (var actionId in SelectedActionsId)
            {
                var newAction = _context.Actions.FirstOrDefault(a => a.Id == actionId);
                ActionFood actionFood = new ActionFood { Action = newAction, Food = Food, ActionId = actionId, FoodId = Food.Id };
                _context.ActionFoods.Add(actionFood);
                await _context.SaveChangesAsync();
            }
        }
    }
}