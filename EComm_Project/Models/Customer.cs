using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm_Project.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public List<Order> Orders { get; set; }

        public List<CreditCard> CreditCards { get; set; }
    }
}
