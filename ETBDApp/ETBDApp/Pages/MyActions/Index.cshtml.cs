

namespace ETBDApp.Pages.MyActions
{
    public class IndexModel : PageModel
    {
        private readonly ETBDApp.Data.ETBDDbContext _context;

        public IndexModel(ETBDApp.Data.ETBDDbContext context)
        {
            _context = context;
        }

        public IList<Action> Action { get;set; }

        public async Task OnGetAsync()
        {
            Action = await _context.Actions.ToListAsync();
        }
    }
}
