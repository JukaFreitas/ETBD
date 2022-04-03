

namespace ETBDApp.Pages.MyBlacklists
{
    public class IndexModel : PageModel
    {
        private readonly ETBDDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(ETBDDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IList<BlackList> BlackList { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            BlackList = await _context.BlackLists.Include(b => b.Food).Where(b=> b.User.Id == user.Id).ToListAsync();
        }
    }
}
