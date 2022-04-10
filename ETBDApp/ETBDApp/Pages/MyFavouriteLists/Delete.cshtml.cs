using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ETBDApp.Data;
using ETBDApp.Data.Entities;

namespace ETBDApp.Pages.My_FavouriteLists
{
    public class DeleteModel : PageModel
    {
        private readonly ETBDApp.Data.ETBDDbContext _context;

        public DeleteModel(ETBDApp.Data.ETBDDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FavouriteList FavouriteList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FavouriteList = await _context.FavouriteLists.FirstOrDefaultAsync(m => m.Id == id);

            if (FavouriteList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FavouriteList = await _context.FavouriteLists.FindAsync(id);

            if (FavouriteList != null)
            {
                _context.FavouriteLists.Remove(FavouriteList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
