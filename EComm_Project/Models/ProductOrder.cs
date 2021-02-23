using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Models
{
    public class ProductOrder
    {
        [DisplayName("Product Order ID")]
        public int ProductOrderId { get; set; }

        public Order Order { get; set; }

        [DisplayName("Order ID")]
        public int OrderId { get; set; }

        public Product Product { get; set; }

        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        [Required]
        public string Quantity { get; set; }

        [DisplayName("Order Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required]
        public decimal OrderPrice { get; set; }
    }
}
