using EComm_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Pages
{
    public class IndexModel2 : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public IndexModel2(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel2(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Order> Order { get; set; }
        public IList<Product> Product { get; set; }

        public IActionResult OnPostViewCartAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            /*var CurrentOrder = new Order();
            //var currentorderexists = true;
            var existingOrderId = 0;

            CurrentOrder = Order.FirstOrDefault(o => o.OrderStatus == false);

            if (CurrentOrder == null)
            {
                *//*var newOrder = new Order();
                newOrder.Date = DateTime.Now;
                newOrder.CustomerId = 0;*/
                /*_context.Order.Add(newOrder);
                _context.SaveChanges();*//*
                existingOrderId = 0;
            }
            else
            {
                // add to existing order
                existingOrderId = CurrentOrder.OrderId;

            }*/

            return RedirectToPage("Orders/RedirectViewCart");
        }
        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
            int no_of_items = Product.Count;

        }

        public IList<Order> Orders { get; set; }
        //public async Task<IActionResult> AddToCart()
        public IActionResult OnPostAddToCartAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            /*var viewOrder = new Order();
            Orders = await _context.Orders.ToListAsync();*/

            return RedirectToPage("Orders/Redirect" );
        }
    }
}
