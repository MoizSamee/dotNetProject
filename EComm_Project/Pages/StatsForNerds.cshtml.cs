using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EComm_Project.Pages
{
    public class StatsForNerdsModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public IndexModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; }
        public IList<Order> Orders { get; set; }
        public IList<Product> Products { get; set; }
        public IList<ProductOrder> ProductOrders { get; set; }
        public IList<CreditCard> CreditCards { get; set; }

        public async void OnGet()
        {
            Products = await _context.Product.ToListAsync();

        }
    }
}
