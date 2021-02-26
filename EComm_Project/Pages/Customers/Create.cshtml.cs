﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EComm_Project.Models;
using EComm_Project_Database.Data;

namespace EComm_Project.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public CreateModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();
            TempData["notice"] = "Welcome" +Customer.LastName;
            return RedirectToPage("/Index");
        }
    }
}
