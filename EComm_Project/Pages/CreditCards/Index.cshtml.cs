using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;
using EComm_Project_Database.Data;
using System.Web.Mvc;

namespace EComm_Project.Pages.CreditCards
{
    public class IndexModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public IndexModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public IList<CreditCard> CreditCard { get;set; }

        public async Task OnGetAsync()
        {
            CreditCard = await _context.CreditCard
                .Include(c => c.Customer).ToListAsync();
        }

        public IActionResult OnPostAddCreditCardAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("/CreditCards/Create");
        }

        public IActionResult OnPostCnfPaymentAsync( )
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["notice"] = "Successfully placed your order";
            /*String Message = "Success"; */
            return RedirectToPage("/Index");
        }
    }
}
