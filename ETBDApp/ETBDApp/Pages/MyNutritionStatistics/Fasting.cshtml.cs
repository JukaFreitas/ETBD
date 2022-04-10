namespace ETBDApp.Pages.MyNutritionStatistics
{
    public class FastingModel : PageModel
    {
        private readonly ETBDDbContext _context;
        private readonly UserManager<User> _userManager;

        public FastingModel(ETBDDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        public double TotalFastingMinutes { get; set; }
        public double CurrentFastingMinutes { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            TotalFastingMinutes = 0;

            var lastMeal = _context.Meals.Where(m => m.User == user).OrderBy(m => m.EndDate).Last();
            var timeSpan = DateTime.Now - lastMeal.EndDate;
            CurrentFastingMinutes = Math.Round(timeSpan.TotalMinutes);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            var meals = _context.Meals.Where(m => m.User == user && m.StartDate >= StartDate && m.EndDate <= EndDate).OrderBy(m => m.StartDate).ToList();

            TimeSpan fastingTimeSpan = meals[0].StartDate - StartDate;

            TotalFastingMinutes += fastingTimeSpan.TotalMinutes;

            for (int i = 0; i < meals.Count(); i++)
            {
                if (i == meals.Count() - 1)
                {
                    fastingTimeSpan = EndDate - meals[i].EndDate;
                }
                else
                {
                    fastingTimeSpan = meals[i + 1].StartDate - meals[i].EndDate;
                }

                TotalFastingMinutes += fastingTimeSpan.TotalMinutes;
            }

            return Page();
        }
    }
}