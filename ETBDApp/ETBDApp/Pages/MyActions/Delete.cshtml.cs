﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ETBDApp.Data;
using ETBDApp.Data.Entities;

namespace ETBDApp.Pages.MyActions
{
    public class DeleteModel : PageModel
    {
        private readonly ETBDApp.Data.ETBDDbContext _context;

        public DeleteModel(ETBDApp.Data.ETBDDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Action Action { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Action = await _context.Actions.FirstOrDefaultAsync(m => m.Id == id);

            if (Action == null)
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

            Action = await _context.Actions.FindAsync(id);

            if (Action != null)
            {
                _context.Actions.Remove(Action);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
