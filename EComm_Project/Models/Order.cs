using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Models
{
    public class Order
    {
        [DisplayName("Order ID")]
        public int OrderId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date")]
        [Required]
        public DateTime Date { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }

        public Customer Customer { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Order Status")]
        public bool OrderStatus { get; set; }
    }
}
