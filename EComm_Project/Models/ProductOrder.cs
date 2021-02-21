using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Models
{
    public class ProductOrder
    {
        public int ProductOrderId { get; set; }

        public Order Order { get; set; }

        public int OrderId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public string Quantity { get; set; }

        public decimal OrderPrice { get; set; }
    }
}
