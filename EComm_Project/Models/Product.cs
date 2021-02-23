using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Models
{
    public class Product
    {
        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public string Category { get; set; }

        [DisplayFormat(DataFormatString ="{0:C}")]
        [Required]
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
