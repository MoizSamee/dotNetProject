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

namespace EComm_Project.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public EditModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (Customer == null)
            {
                return NotFound();
            }
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


            _context.Attach(Customer).State = EntityState.Modified;

            int ph_length = Customer.PhoneNumber.Length;

            int birthYear = Customer.DOB.Year;
            int lastAllowedYear = DateTime.Now.Year - 18;

            if (ph_length != 10)
            {
                ModelState.AddModelError(key: "Customer.PhoneNumber", errorMessage: "Phone Number must be 10 digits");

            }
            if (birthYear > lastAllowedYear)
            {
                ModelState.AddModelError(key: "Customer.DOB", errorMessage: "Must be older than 18 years");

            }
            if (!ModelState.IsValid)
            {

                return Page();
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
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

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }
    }
}
