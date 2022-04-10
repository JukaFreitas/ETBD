namespace ETBDApp.Pages.MyNutritionDiary
{
    public class DetailsModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public DetailsModel(ETBDDbContext context)
        {
            _context = context;
        }

        public Meal Meal { get; set; }

        [BindProperty]
        public MealType MealTypes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meal = await _context.Meals
                .Include(m => m.FoodMeals).ThenInclude(m => m.PortionTypes)
                .Include(m => m.FoodMeals).ThenInclude(m => m.Food)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Meal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}