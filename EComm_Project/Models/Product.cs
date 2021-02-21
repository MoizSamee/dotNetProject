using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }


        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        //public int Quantity { get; set; }

        public bool Availability { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }

        /*public Product (int ProductId)
        {

        }*/
    }
}
