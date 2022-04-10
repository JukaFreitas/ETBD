namespace ETBDApp.Areas.Identity.Pages.Account.Manager
{
    public class ImporterModel : PageModel
    {
        private readonly ETBDDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICSVImporter _csvImporter;

        public ImporterModel(ETBDDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, ICSVImporter csvImporter)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _csvImporter = csvImporter;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _csvImporter.Import();

            ViewData["Message"] = "Import completed";

            return Page();
        }
    }
}