using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EComm_Project.Models;

namespace EComm_Project_Database.Data
{
    public class EComm_ProjectContext : DbContext
    {
        public EComm_ProjectContext (DbContextOptions<EComm_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<EComm_Project.Models.Product> Product { get; set; }

        public DbSet<EComm_Project.Models.ProductOrder> ProductOrder { get; set; }

        public DbSet<EComm_Project.Models.Order> Order { get; set; }

        public DbSet<EComm_Project.Models.Customer> Customer { get; set; }

        public DbSet<EComm_Project.Models.CreditCard> CreditCard { get; set; }
    }
}
