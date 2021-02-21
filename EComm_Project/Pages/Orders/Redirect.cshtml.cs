using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;
using EComm_Project_Database.Data;
using System.IO;

namespace EComm_Project.Pages.Orders
{
    public class RedirectModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public RedirectModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

       
        public async Task<RedirectToPageResult> OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Customer).ToListAsync();

            var CurrentOrder = new Order();
            var currentorderexists = true;

            try 
            {
                CurrentOrder = Order.FirstOrDefault(o => o.OrderStatus = false);
                currentorderexists = CurrentOrder.OrderStatus;
            }

            catch (NullReferenceException e)
            {
                if (CurrentOrder == null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                currentorderexists = true;
            }

            var existingOrderId = 0;

            if (currentorderexists == false)
            {
                // add to existing order
                existingOrderId = CurrentOrder.OrderId;
            }
            else
            {
                //create a new order
                var newOrder = new Order();
                _context.Order.Add(newOrder);
                _context.SaveChanges();
            }

            return RedirectToPage("/ProductOrders/Create", new { orderId = existingOrderId });


        }
    }
}
