
namespace ETBDApp.Pages.MyFoods
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
        public Food Food { get; set; }

        public SelectList Categories { get; set; }

        [BindProperty]
        public int SelectedCategoryId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                
                return Page();
            }

            _context.Foods.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
