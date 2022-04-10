
namespace ETBDApp.Pages.My_FavouriteLists
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

        public IList<FavouriteList> FavouriteList { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            FavouriteList = await _context.FavouriteLists.Include(f=> f.Food).Where(f => f.User.Id == user.Id).ToListAsync();
        }
    }
}
