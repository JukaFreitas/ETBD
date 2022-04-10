namespace ETBDApp.Pages.MyNutritionDiary
{
    public class IndexModel : PageModel
    {
        private readonly ETBDDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(ETBDDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Meal> Meal { get; set; }
        public IList<MealType> MealTypes { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            
            Meal = await _context.Meals.Include(m => m.MealType).Where(m=>m.User == user).ToListAsync();
        }
    }
}