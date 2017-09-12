using System;
using System.Collections.Generic;
using System.Text;

namespace CommercyDomain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string NameCustomer { get; set; }
        public DateTime DtaBirth { get; set; }
        public string NumberPersonalDocument { get; set; }
        public string AddressCustomer { get; set; }

        public virtual AccountShopping AccountShopping { get; set; }
    }
}
