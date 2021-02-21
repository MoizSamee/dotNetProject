using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EComm_Project.Models;
using EComm_Project_Database.Data;
using Microsoft.EntityFrameworkCore;

namespace EComm_Project.Pages.ProductOrders
{
    public class CreateModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public CreateModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? OrderId)
        {
            //var OrderPrice_List = _context.Product.ToLookup(x => x.ProductId);
            //var newProduct = _context.Product.FirstOrDefaultAsync(m => m.ProductId == ProductId);

            /*  ViewData["OrderPrice"]= newProduct.Price*/
            //ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId");
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId",OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId");
            return Page();
        }

       
        [BindProperty]
        public ProductOrder ProductOrder { get; set; }

        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductOrder.Add(ProductOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
