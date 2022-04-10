namespace ETBDApp.Pages.MyActions
{
    public class IndexModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public IndexModel(ETBDDbContext context)
        {
            _context = context;
        }

        public IList<Action> Action { get; set; }

        public async Task OnGetAsync()
        {
            Action = await _context.Actions.ToListAsync();
        }
    }
}