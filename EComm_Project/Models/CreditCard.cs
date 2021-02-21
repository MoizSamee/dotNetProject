using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public DateTime ExpirationDate { get; set; }

        //public int Cvv { get; set; }

        public string CardHolderFirstName { get; set; }

        public string CardHolderLastName { get; set; }

        public string CardNumber { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
    }
}
