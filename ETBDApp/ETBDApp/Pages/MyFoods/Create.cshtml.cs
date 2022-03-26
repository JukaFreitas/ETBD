using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ETBDApp.Data;
using ETBDApp.Data.Entities;

namespace ETBDApp.Pages.MyFoods
{
    public class CreateModel : PageModel
    {
        private readonly ETBDApp.Data.ETBDDbContext _context; 

        public CreateModel(ETBDApp.Data.ETBDDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            this.Categories = new SelectList(_context.Categories, "Id",  "CategoryName"); 

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

            ModelState.Clear();
            TryValidateModel(Food);
            TryValidateModel(Food.Category);

            if (!ModelState.IsValid)
            {
                this.Categories = new SelectList(_context.Categories, "Id", "CategoryName");
                return Page();
            }

            _context.Foods.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
