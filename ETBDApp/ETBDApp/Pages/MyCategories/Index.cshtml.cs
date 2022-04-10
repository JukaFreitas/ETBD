namespace ETBDApp.Pages.MyCategories
{
    public class IndexModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public IndexModel(ETBDDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}