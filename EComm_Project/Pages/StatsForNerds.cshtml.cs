using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;
using EComm_Project_Database.Data;

namespace EComm_Project.Pages
{
    public class StatsForNerdsModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public StatsForNerdsModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; }
        public IList<Order> Orders { get; set; }
        public IList<Product> Products { get; set; }
        public IList<ProductOrder> ProductOrders { get; set; }
        public IList<CreditCard> CreditCards { get; set; }

        int C_Products = 0;

        public async void OnGet()
        {
            Products = await _context.Product.ToListAsync();
            C_Products = Products.Count();
            Customers = await _context.Customer.ToListAsync();
            Orders = await _context.Order.ToListAsync();
            ProductOrders = await _context.ProductOrder.ToListAsync();
            CreditCards = await _context.CreditCard.ToListAsync();
        }
    }
}
