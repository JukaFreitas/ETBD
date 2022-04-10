namespace ETBDApp.Pages.MyNutritionDiary
{
    public class AddFoodMealModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public AddFoodMealModel(ETBDDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            this.SelectedListFoods = new SelectList(_context.Foods, "Id", "Name");
            this.SelectedListPortionType = new SelectList(_context.PortionTypes, "Id", "Type");
            this.SelectedListPortionQuantity = new SelectList(_context.FoodMeals, "Id", "Portion");
            return Page();
        }

        [BindProperty]
        public FoodMeal FoodMeal { get; set; }

        [BindProperty]
        public Food Food { get; set; }

        [BindProperty]
        public int SelectedPortionId { get; set; }

        [BindProperty]
        public int SelectedFoodId { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public PortionType PortionTypes { get; set; }

        public SelectList SelectedListPortionQuantity { get; set; }
        public SelectList SelectedListPortionType { get; set; }
        public SelectList SelectedListFoods { get; set; }

        public async Task<IActionResult> OnPostAsync(int mealId)
        {
            Meal meal = _context.Meals.Include(m => m.FoodMeals).FirstOrDefault(m => m.Id == mealId);
            FoodMeal.PortionTypes = _context.PortionTypes.FirstOrDefault(pt => pt.Id == SelectedPortionId);
            FoodMeal.Food = _context.Foods.Include(f => f.Category).FirstOrDefault(fm => fm.Id == SelectedFoodId);
            FoodMeal.Quantity = Quantity;

            meal.FoodMeals.Add(FoodMeal);
            ModelState.Clear();
            TryValidateModel(FoodMeal);

            if (ModelState.IsValid)
            {
                ViewData["Message"] = "Food Added";
                _context.Meals.Update(meal);
                await _context.SaveChangesAsync();
            }
            this.SelectedFoodId = 0;
            this.SelectedPortionId = 0;
            this.Quantity = 0;

            this.SelectedListFoods = new SelectList(_context.Foods, "Id", "Name");
            this.SelectedListPortionType = new SelectList(_context.PortionTypes, "Id", "Type");
            this.SelectedListPortionQuantity = new SelectList(_context.FoodMeals, "Id", "Portion");
            return Page();
        }
    }
}