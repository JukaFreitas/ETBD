namespace ETBDApp.Pages.MyBlacklists
{
    public class CreateModel : PageModel
    {
        private readonly ETBDDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateModel(ETBDDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            this.Foods = new SelectList(_context.Foods, "Id", "Name");

            return Page();
        }

        [BindProperty]
        public BlackList BlackList { get; set; }

        public SelectList Foods { get; set; }

        [BindProperty]
        public int SelectedFoodId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            BlackList.User = await _userManager.GetUserAsync(User);

            if (_context.BlackLists.Any(f => f.Food.Id == SelectedFoodId && f.User.Id == BlackList.User.Id))
            {
                ViewData["Message"] = "You have already added this food!";

                this.Foods = new SelectList(_context.Foods, "Id", "Name");
                return Page();
            }

            BlackList.Food = _context.Foods.Include(f => f.Category).Where(f => f.Id == SelectedFoodId).ToList().FirstOrDefault();
            BlackList.CreationDate = DateTime.Now;

            ModelState.Clear();
            TryValidateModel(BlackList);

            if (!ModelState.IsValid)
            {
                this.Foods = new SelectList(_context.Foods, "Id", "Name");
                return Page();
            }

            _context.BlackLists.Add(BlackList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}