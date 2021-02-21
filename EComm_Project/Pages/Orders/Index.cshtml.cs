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
    public class IndexModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public IndexModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Customer).ToListAsync();
        }

        /*public async Task<RedirectToPageResult> OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Customer).ToListAsync();

            Order CurrentOrder = Order.FirstOrDefault(o => o.Order_Status = false);

            var currentorderexists = CurrentOrder.Order_Status;
            
            if (currentorderexists == false)
            {
                // add to existing order
                var existingOrderId = CurrentOrder.OrderId;
            }
            else
            {
                //create a new order
                var newOrder = new Order();
                _context.Order.Add(newOrder);
                _context.SaveChanges();
            }

            return RedirectToPage("/ProductOrders/Index");


        }*/
    }
}
