namespace ETBDApp.Pages.MyBlacklists
{
    public class DetailsModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public DetailsModel(ETBDDbContext context)
        {
            _context = context;
        }

        public BlackList BlackList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlackList = await _context.BlackLists.FirstOrDefaultAsync(m => m.Id == id);

            if (BlackList == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}