using System;
using System.Collections.Generic;
using System.Text;

namespace CommercyDomain.Entities
{
    public class AccountShopping
    {
        public AccountShopping()
        {
            this.LstShoppingExecuted = new List<ShoppingExecuted>();
        }
        public int AccountShoppingId { get; set; }
        public int CustomerIdAccountShopping { get; set; }
        public bool ActiveAccountShopping { get; set; }
        public DateTime DtaAccountShopping { get; set; }

        public virtual Customer CustomerAccountShopping { get; set; }
        public virtual List<ShoppingExecuted> LstShoppingExecuted { get; set; }

    }
}
