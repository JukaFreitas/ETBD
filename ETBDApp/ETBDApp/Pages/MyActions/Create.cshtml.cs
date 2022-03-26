﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ETBDApp.Data;
using ETBDApp.Data.Entities;

namespace ETBDApp.Pages.MyActions
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
            return Page();
        }

        [BindProperty]
        public Action Action { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Actions.Add(Action);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}