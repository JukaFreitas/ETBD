namespace ETBDApp.Pages.MyNutritionStatistics
{
    public class NutritionStatisticsModel : PageModel
    {
        private readonly ETBDDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IDayValidator _validator;

        public NutritionStatisticsModel(ETBDDbContext context, UserManager<User> userManager, IDayValidator validator)
        {
            _context = context;
            _userManager = userManager;
            _validator = validator;
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
                if (_validator.IsSucessfulDay(user, day))
                {
                    SuccessfulDays.Add(day.ToString("dd-MM-yyyy"));
                    
                }
                else
                {
                    FailedDays.Add(day.ToString("dd-MM-yyyy"));
                }
            }
            return Page();
        }
    }
}