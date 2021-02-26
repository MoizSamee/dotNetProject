using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EComm_Project.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostLoginAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TempData["notice"] = "Welcome";
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostCreateUserAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["notice"] = "Welcome";

            return RedirectToPage("/Customers/Create");
        }
    }
}
