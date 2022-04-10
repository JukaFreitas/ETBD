namespace ETBDApp.Data.Validators
{
    public class DayValidator : IDayValidator
    {
        private readonly ETBDDbContext _context;
        private List<Action> _missingActions { get; set; }

        public DayValidator(ETBDDbContext context)
        {
            _context = context;
            _missingActions = new List<Action>();
        }

        public bool IsSucessfulDay(User user, DateTime day)
        {
            _missingActions.Clear();
            var actionsPerDay = new List<Action>();
            var meals = _context.Meals.Where(m => m.User.Id == user.Id && m.StartDate.Date >= day && m.EndDate.Date <= day).Include(m => m.FoodMeals);
            var foodCount = 0;

            if (meals.Count() > 5)
            {
                return false;
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
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool HasAllActions(List<Action> actionsPerDay)
        {
            foreach (var action in _context.Actions)
            {
                if (!actionsPerDay.Any(ad => ad.Id == action.Id))
                {
                    _missingActions.Add(action);
                    return false;
                }
            }
            return true;
        }

        public List<Action> GetMissingActions()
        {
            return _missingActions;
        }
    }
}