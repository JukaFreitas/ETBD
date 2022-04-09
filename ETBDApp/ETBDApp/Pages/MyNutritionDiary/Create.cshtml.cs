using Microsoft.AspNetCore.Http;

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
            this.SelectedListFoods = new SelectList ( _context.Foods, "Id", "Name" );
            this.SelectedListPortionType = new SelectList(_context.PortionTypes, "Id", "Type"); 
            this.SelectedListPortionQuantity = new SelectList(_context.FoodMeals, "Id", "Portion");
            this.SelectedListMealType = new SelectList(_context.MealTypes, "Id", "Type");
            return Page();
        }

        [BindProperty]
        public Meal Meals { get; set; }

        [BindProperty]
        public FoodMeal FoodMeals { get; set; }

        [BindProperty]
        public MealType MealTypes { get; set; }

        [BindProperty]
        public Food Foods { get; set; }

        [BindProperty]
        public int SelectedPortionId { get; set; }

        [BindProperty]
        public int SelectedMealTypeId { get; set; }

        [BindProperty]
        public int SelectedFoodId { get; set; }

        public SelectList SelectedListPortionQuantity { get; set; }
        public PortionType PortionTypes { get; set; }

        public SelectList SelectedListPortionType { get; set; }
        public SelectList SelectedListFoods { get; set; }
        public SelectList SelectedListMealType { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Meals.User = await _userManager.GetUserAsync(User);

            FoodMeals.PortionTypes = _context.PortionTypes.FirstOrDefault(pt => pt.Id == SelectedPortionId);
            Meals.MealType = _context.MealTypes.FirstOrDefault(mt => mt.Id == SelectedMealTypeId);
            FoodMeals.Food = _context.Foods.Include(f => f.Category).FirstOrDefault(fm => fm.Id == SelectedFoodId);

            Meals.FoodMeals = new List<FoodMeal> { FoodMeals };
            ModelState.Clear();
            TryValidateModel(Meals);

            if (!ModelState.IsValid)
            {
                this.SelectedListFoods = new SelectList(_context.Foods, "Id", "Name");
                this.SelectedListPortionType = new SelectList(_context.PortionTypes, "Id", "Type");
                this.SelectedListPortionQuantity = new SelectList(_context.FoodMeals, "Id", "Portion");
                this.SelectedListMealType = new SelectList(_context.MealTypes, "Id", "Type");
                return Page();
            }

            _context.Meals.Add(Meals);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}
