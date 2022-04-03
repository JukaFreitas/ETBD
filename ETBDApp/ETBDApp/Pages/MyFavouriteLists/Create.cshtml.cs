namespace ETBDApp.Pages.My_FavouriteLists
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
        public FavouriteList FavouriteList { get; set; }

        public SelectList Foods { get; set; }

        [BindProperty]
        public int SelectedFoodId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            FavouriteList.User = await _userManager.GetUserAsync(User);
            if (_context.FavouriteLists.Any(f => f.Food.Id == SelectedFoodId && f.User.Id == FavouriteList.User.Id))
            {
                ViewData["Message"] = "You have already added this food!";

                this.Foods = new SelectList(_context.Foods, "Id", "Name");
                return Page();
            }
            else
            {
                FavouriteList.Food = _context.Foods.Include(f => f.Category).Where(f => f.Id == SelectedFoodId).ToList().FirstOrDefault();
                FavouriteList.CreationDate = DateTime.Now;

                ModelState.Clear();
                TryValidateModel(FavouriteList);

                if (!ModelState.IsValid)
                {
                    this.Foods = new SelectList(_context.Foods, "Id", "Name");
                    return Page();
                }

                _context.FavouriteLists.Add(FavouriteList);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }
    }
}