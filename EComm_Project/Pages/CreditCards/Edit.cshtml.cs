using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;
using EComm_Project_Database.Data;

namespace EComm_Project.Pages.CreditCards
{
    public class EditModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public EditModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreditCard CreditCard { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CreditCard = await _context.CreditCard
                .Include(c => c.Customer).FirstOrDefaultAsync(m => m.CreditCardId == id);

            if (CreditCard == null)
            {
                return NotFound();
            }
           ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CreditCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditCardExists(CreditCard.CreditCardId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CreditCardExists(int id)
        {
            return _context.CreditCard.Any(e => e.CreditCardId == id);
        }
    }
}
