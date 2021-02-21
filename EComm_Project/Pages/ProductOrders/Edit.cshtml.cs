using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;
using EComm_Project_Database.Data;

namespace EComm_Project.Pages.ProductOrders
{
    public class EditModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public EditModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductOrder ProductOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductOrder = await _context.ProductOrder
                .Include(p => p.Order)
                .Include(p => p.Product).FirstOrDefaultAsync(m => m.ProductOrderId == id);

            if (ProductOrder == null)
            {
                return NotFound();
            }
           ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId");
           ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOrderExists(ProductOrder.ProductOrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductOrderExists(int id)
        {
            return _context.ProductOrder.Any(e => e.ProductOrderId == id);
        }
    }
}
