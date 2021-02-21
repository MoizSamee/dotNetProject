using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;
using EComm_Project_Database.Data;

namespace EComm_Project.Pages.CreditCards
{
    public class DeleteModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public DeleteModel(EComm_Project_Database.Data.EComm_ProjectContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CreditCard = await _context.CreditCard.FindAsync(id);

            if (CreditCard != null)
            {
                _context.CreditCard.Remove(CreditCard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
