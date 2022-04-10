namespace ETBDApp.Pages.MyActions
{
    public class CreateModel : PageModel
    {
        private readonly ETBDDbContext _context;

        public CreateModel(ETBDDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Action Action { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Actions.Add(Action);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}