namespace ETBDApp.Pages.My_FavouriteLists
{
    public class DetailsModel : PageModel
    {
        private readonly ETBDApp.Data.ETBDDbContext _context;

        public DetailsModel(ETBDApp.Data.ETBDDbContext context)
        {
            _context = context;
        }

        public FavouriteList FavouriteList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FavouriteList = await _context.FavouriteLists.FirstOrDefaultAsync(m => m.Id == id);

            if (FavouriteList == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}