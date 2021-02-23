using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Models
{
    public class CreditCard
    {
        [DisplayName("ID")]
        public int CreditCardId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Expiration Date")]
        [Required]
        public DateTime ExpirationDate { get; set; }

        //public int Cvv { get; set; }

        [DisplayName("First Name")]
        [Required]
        [StringLength(50)]
        public string CardHolderFirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [StringLength(50)]
        public string CardHolderLastName { get; set; }

        [DisplayName("Credit Card Number")]
        [Required(ErrorMessage = "Please enter a valid Credit Card Number")]
        [CreditCard]
        public string CardNumber { get; set; }

        public Customer Customer { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }
    }
}
