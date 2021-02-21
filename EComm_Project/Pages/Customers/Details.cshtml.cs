using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;
using EComm_Project_Database.Data;

namespace EComm_Project.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public DetailsModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public IList<Order> Orders { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Orders = await _context.Order
                .Include(o => o.Customer).ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerId == id);


            if (Customer == null)
            {
                return NotFound();
            }
            

            return Page();
        }
    }
}

