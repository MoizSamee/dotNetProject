using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;
using EComm_Project_Database.Data;

namespace EComm_Project.Pages.ProductOrders
{
    public class IndexModel : PageModel
    {
        private readonly EComm_Project_Database.Data.EComm_ProjectContext _context;

        public IndexModel(EComm_Project_Database.Data.EComm_ProjectContext context)
        {
            _context = context;
        }

        public IList<ProductOrder> ProductOrder { get;set; }

        public async Task OnGetAsync()
        {
            ProductOrder = await _context.ProductOrder
                .Include(p => p.Order)
                .Include(p => p.Product).ToListAsync();
        }

        
    }
}
