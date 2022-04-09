namespace ETBDApp.Pages.MyNutritionStatistics
{
    public class NutritionStatisticsModel : PageModel
    {
        private readonly ETBDDbContext _context;
        private readonly UserManager<User> _userManager;

        public NutritionStatisticsModel(ETBDDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty, DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [BindProperty]
        [Display(Name = "Successful Days")]
        public List<string> SuccessfulDays { get; set; }

        [BindProperty]
        [Display(Name = "Failed Days")]
        public List<string> FailedDays { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            SuccessfulDays = new List<string>();
            FailedDays = new List<string>();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            for (var day = StartDate.Date; day <= EndDate.Date; day = day.AddDays(1))
            {
                ValidatedActionsPerDay(user, day);
            }
            return Page();
        }

        private void ValidatedActionsPerDay(User user, DateTime day)
        {
            var actionsPerDay = new List<Action>();
            var meals = _context.Meals.Where(m => m.User.Id == user.Id && m.StartDate.Date >= day && m.EndDate.Date <= day).Include(m => m.FoodMeals);
            var foodCount = 0;

            if (meals.Count() > 5)
            {
                FailedDays.Add(day.ToString("dd-MM-yyyy"));
            }

            foreach (var meal in meals)
            {
                foreach (var foodMeal in meal.FoodMeals)
                {
                    var actionFoods = _context.ActionFoods.Where(af => af.FoodId == foodMeal.FoodId).Select(af => af.Action);
                    actionsPerDay.AddRange(actionFoods);
                    foodCount++;
                }
            }

            if (HasAllActions(actionsPerDay) && foodCount >= 5)
            {
                SuccessfulDays.Add(day.ToString("dd-MM-yyyy"));
            }
            else
            {
                FailedDays.Add(day.ToString("dd-MM-yyyy"));
            }
        }

        private bool HasAllActions(List<Action> actionsPerDay)
        {
            foreach (var action in _context.Actions)
            {
                if (!actionsPerDay.Any(ad => ad.Id == action.Id))
                {
                    return false;
                }
            }
            return true;
        }
    }
}