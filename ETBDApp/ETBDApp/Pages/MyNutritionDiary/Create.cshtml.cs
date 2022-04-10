namespace ETBDApp.Pages.MyNutritionDiary
{
    public class CreateModel : PageModel
    {
        private readonly ETBDDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateModel(ETBDDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            this.SelectedListMealType = new SelectList(_context.MealTypes, "Id", "Type");
            return Page();
        }

        [BindProperty]
        public Meal Meal { get; set; }

        [BindProperty]
        public MealType MealTypes { get; set; }

        [BindProperty]
        public int SelectedMealTypeId { get; set; }

        public SelectList SelectedListMealType { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Meal.User = await _userManager.GetUserAsync(User);

            Meal.MealType = _context.MealTypes.FirstOrDefault(mt => mt.Id == SelectedMealTypeId);

            Meal.FoodMeals = new List<FoodMeal>();

            ModelState.Clear();
            TryValidateModel(Meal);

            if (!ModelState.IsValid)
            {
                this.SelectedListMealType = new SelectList(_context.MealTypes, "Id", "Type");
                return Page();
            }

            _context.Meals.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./AddFoodMeal", new { mealId = Meal.Id });
        }
    }
}