﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ETBDApp.Data;
using ETBDApp.Data.Entities;

namespace ETBDApp.Pages.MyFoods
{
    public class IndexModel : PageModel
    {
        private readonly ETBDApp.Data.ETBDDbContext _context;

        public IndexModel(ETBDApp.Data.ETBDDbContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; }

        public async Task OnGetAsync()
        {
            Food = await _context.Foods.Include(f => f.Category).ToListAsync();
        }
    }
}
