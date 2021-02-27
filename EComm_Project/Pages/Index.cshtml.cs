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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Order> Order { get; set; }

        public IActionResult OnPostViewCartAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            return RedirectToPage("/UnderConstruction");
        }

        public IActionResult OnPostLoginAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            return RedirectToPage("/Login");
        }
        public void OnGet()
        {
            

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

        public IActionResult OnPostOrderAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            /*var viewOrder = new Order();
            Orders = await _context.Orders.ToListAsync();*/

            return RedirectToPage("Products/AllProducts");
        }
    }
}
