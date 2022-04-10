

namespace ETBDApp.Pages.MyBlacklists
{
    public class EditModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public EditModel(ETBDDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BlackList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlackListExists(BlackList.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BlackListExists(int id)
        {
            return _context.BlackLists.Any(e => e.Id == id);
        }
    }
}
