using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;
using EComm_Project_Database.Data;

namespace EComm_Project.Pages.Orders
{
    public class CartDetailsModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public CartDetailsModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }


        public List<ProductOrder> ProductOrders { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Order = await _context.Order
                 .Include(o => o.Customer).FirstOrDefaultAsync(m => m.OrderId == id);
            ProductOrders = await _context.ProductOrder
                .Include(p => p.Order)
                .Include(p => p.Product).ToListAsync();


            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
