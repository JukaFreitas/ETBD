namespace ETBDApp.Pages.MyFoods
{
    public class IndexModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public IndexModel(ETBDDbContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; }

        public async Task OnGetAsync()
        {
            Food = await _context.Foods.Include(f => f.Category).ToListAsync();            
        }
    }
}
