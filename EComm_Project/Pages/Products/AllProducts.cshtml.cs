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

namespace EComm_Project.Pages.Products
{
    public class AllProductsModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public AllProductsModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        
        public async Task OnGetAsync(int? ProductId)
        {
            Product = await _context.Product.ToListAsync();
            
        }

        public IActionResult OnPostAddToCartAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            /*var viewOrder = new Order();
            Orders = await _context.Orders.ToListAsync();*/
            /*int i = 2;*/
            return RedirectToPage("/Orders/Redirect");
        }
    }
}
