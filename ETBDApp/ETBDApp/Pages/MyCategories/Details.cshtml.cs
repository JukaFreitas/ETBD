using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ETBDApp.Data;
using ETBDApp.Data.Entities;

namespace ETBDApp.Pages.MyCategories
{
    public class DetailsModel : PageModel
    {
        private readonly ETBDApp.Data.ETBDDbContext _context;

        public DetailsModel(ETBDApp.Data.ETBDDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
