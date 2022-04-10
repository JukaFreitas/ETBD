using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ETBDApp.Data;
using ETBDApp.Data.Entities;

namespace ETBDApp.Pages.MyBlacklists
{
    public class DeleteModel : PageModel
    {
        private readonly ETBDApp.Data.ETBDDbContext _context;

        public DeleteModel(ETBDApp.Data.ETBDDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlackList = await _context.BlackLists.FindAsync(id);

            if (BlackList != null)
            {
                _context.BlackLists.Remove(BlackList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
