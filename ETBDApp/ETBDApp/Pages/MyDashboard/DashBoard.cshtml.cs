namespace ETBDApp.Pages.MyDashboard
{
    public class DashBoardModel : PageModel
    {
        private readonly ETBDDbContext _eTBDDbContext;

        public DashBoardModel(ETBDDbContext eTBDDbContext)
        {
            _eTBDDbContext = eTBDDbContext;
        }

        [Display(Name = "Total Customers")]
        public int CustomersCount { get; set; }

        [Display(Name = "Total Meals")]
        public int MealsCount { get; set; }

        [Display(Name = "Top 10 Food")]
        public IEnumerable<string> TopFoods { get; set; }

        [Display(Name = "Top 5 Users with more meals")]
        public IEnumerable<string> TopUsersMeals { get; set; }

        public IActionResult OnGet()
        {
            CustomersCount = GetCustomersCount();

            MealsCount = GetMealsCount();

            TopFoods = GetTopFood();

            TopUsersMeals = GetTopUsersMeals();

            return Page();
        }

        private IEnumerable<string> GetTopUsersMeals()
        {
            var topValue = 5;

            var mealsByOrder = _eTBDDbContext.Meals.GroupBy(m => m.User.Id).OrderByDescending(m => m.Count()).Take(topValue);

            // .First utiliza a primeira meal inserida.

            var usersName = mealsByOrder.Select(m => m.First().User.UserName + ";");

            return usersName;
        }

        private IEnumerable<string> GetTopFood()
        {
            var topValue = 10;

            var topFoods = _eTBDDbContext.FoodMeals.GroupBy(f => f.FoodId).OrderByDescending(f => f.Count()).Take(topValue);

            var foodName = topFoods.Select(m => m.First().Food.Name + ";");

            return foodName;
        }

        private int GetMealsCount()
        {
            var meals = _eTBDDbContext.Meals.Count();
            return meals;
        }

        private int GetCustomersCount()
        {
            var customerRole = _eTBDDbContext.Roles.FirstOrDefault(r => r.Name.Equals(RoleType.Customer.ToString()));

            var customerCount = _eTBDDbContext.UserRoles.Where(u => u.RoleId == customerRole.Id).Count();

            return customerCount;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}