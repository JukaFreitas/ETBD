namespace ETBDApp.Data
{
    public class CSVImporter : ICSVImporter
    {
        private readonly ETBDDbContext _context;

        public CSVImporter(ETBDDbContext context)
        {
            _context = context;
        }

        public void Import()
        {
            string path = @"Files\ETBDDb.csv";

            string[] lines = File.ReadAllLines(path);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');

                if (_context.Foods.Any(x => x.Name.Equals(columns[0])))
                {
                    continue;
                }

                Category category;

                var categoryName = columns[1];

                if (!_context.Categories.Any(x => x.Name.Equals(categoryName)))
                {
                    category = new Category() { Name = categoryName };
                }
                else
                {
                    category = _context.Categories.FirstOrDefault(x => x.Name.Equals(categoryName));
                }

                var food = new Food() { Name = columns[0], Category = category };

                _context.Foods.Add(food);
                _context.SaveChanges();

                ImportActions(columns, food);
            }
        }

        private void ImportActions(string[] columns, Food food)
        {
            Action action;
            var actionsNames = columns[2].Trim().Split(';');

            foreach (var actionName in actionsNames)
            {
                if (!_context.Actions.Any(x => x.Name.Equals(actionName)))
                {
                    action = new Action() { Name = actionName };
                    _context.Actions.Add(action);
                    _context.SaveChanges();
                }
                else
                {
                    action = _context.Actions.FirstOrDefault(x => x.Name.Equals(actionName));
                }

                var actionFood = new ActionFood() { Action = action, Food = food, ActionId = action.Id, FoodId = food.Id };
                _context.ActionFoods.Add(actionFood);
                _context.SaveChanges();
            }
        }
    }
}