namespace ETBDApp.Pages.MyActions
{
    public class DetailsModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public DetailsModel(ETBDDbContext context)
        {
            _context = context;
        }

        public Action Action { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Action = await _context.Actions.FirstOrDefaultAsync(m => m.Id == id);

            if (Action == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
