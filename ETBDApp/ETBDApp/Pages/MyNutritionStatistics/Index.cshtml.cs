namespace ETBDApp.Pages.MyNutritionStatistics
{
    public class IndexModel : PageModel
    {
        private readonly ETBDDbContext _context;
        private readonly IDayValidator _validator;
        private readonly UserManager<User> _userManager;
        public bool SucessfulDay { get; set; }

        public IndexModel(ETBDDbContext context, IDayValidator validator, UserManager<User> userManager)
        {
            _context = context;
            _validator = validator;
            _userManager = userManager;
            SucessfulDay = false;
        }

        [Display(Name = "Suggestion for the day")]
        public List<Food> RecomendedFoods { get; set; }

        public async Task OnGetAsync()
        {
            RecomendedFoods = new List<Food>();

            var user = await _userManager.GetUserAsync(User);

            SucessfulDay = _validator.IsSucessfulDay(user, DateTime.Today);

            if (!SucessfulDay)
            {
                var missingActions = _validator.GetMissingActions();

                if (!missingActions.Any())
                {
                    missingActions = _context.Actions.ToList();
                    // no caso de te nao ter os cinco alimentos, mas ja ter as cinco açoes. 
                }

                foreach (var missingAction in missingActions)
                {
                    var favouriteActionFoods = new List<Food>();

                    var actionFoods = _context.ActionFoods.Where(af => af.ActionId == missingAction.Id).Include(af => af.Food).Select(af => af.Food).ToList();
                    AddRecommendedFoods(user, favouriteActionFoods, actionFoods);
                }
            }
        }

        private void AddRecommendedFoods(User user, List<Food> favouriteActionFoods, List<Food> actionFoods)
        {
            foreach (var actionFood in actionFoods)
            {
                var favouriteActionFood = _context.FavouriteLists.Include(f => f.Food).FirstOrDefault(fl => fl.Food.Id == actionFood.Id && fl.User == user);

                if (favouriteActionFood != null)
                {
                    favouriteActionFoods.Add(favouriteActionFood.Food); 
                }
            }

            if (favouriteActionFoods.Any())
            {
                RecomendedFoods.AddRange(favouriteActionFoods);
            }
            else
            {
                var blackListFoods = _context.BlackLists.Where(bl => bl.User == user).Include(bl => bl.Food).Select(bl => bl.Food);

                foreach (var blackListFood in blackListFoods)
                {
                    actionFoods.Remove(blackListFood);
                }

                RecomendedFoods.Add(actionFoods.First());
                RecomendedFoods.Add(actionFoods.Last());

            }

            RecomendedFoods = RecomendedFoods.Distinct().ToList();
        }
    }
}