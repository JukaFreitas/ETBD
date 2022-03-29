

namespace ETBDApp.Pages.MyFoods
{
    public class IndexModel : PageModel
    {
        private readonly ETBDApp.Data.ETBDDbContext _context;

        public IndexModel(ETBDApp.Data.ETBDDbContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; }

        public async Task OnGetAsync()
        {
            var csvImporter = new CSVImporter(_context);

            csvImporter.Import();
            

            Food = await _context.Foods.Include(f => f.Category).ToListAsync();
            
        }
    }
}
