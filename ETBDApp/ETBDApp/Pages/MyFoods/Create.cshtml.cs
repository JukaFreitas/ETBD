using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


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
            Categories = new SelectList(_context.Categories, "Id",  "Name"); 

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
            Food.Category = _context.Categories.Where(c => c.Id == SelectedCategoryId).FirstOrDefault();
            //Deu erro, porque não o category não está preenchido. 
            //Necessidade de revalidar, quando o category já está preenchido
            ModelState.Clear();
            TryValidateModel(Food);
            TryValidateModel(Food.Category);

            if (!ModelState.IsValid)
            {
                Categories = new SelectList(_context.Categories, "Id", "Name");
                return Page();
            }

            _context.Foods.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
