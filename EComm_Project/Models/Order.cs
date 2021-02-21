using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime Date { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public bool OrderStatus;
    }
}
