
namespace ETBDApp.Pages.MyNutritionDiary
{
    public class IndexModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public IndexModel(ETBDApp.Data.ETBDDbContext context)
        {
            _context = context;
        }

        public IList<Meal> Meal { get;set; }
        public IList<MealType> MealTypes { get; set; }
        public async Task OnGetAsync()
        {
            Meal = await _context.Meals.Include(m=> m.MealType).ToListAsync();
        }
    }
}
