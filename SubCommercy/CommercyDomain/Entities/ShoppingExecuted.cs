using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommercyDomain.Entities
{
    public class ShoppingExecuted
    {
        public int ShoppingExecutedId { get; set; }
        public decimal TotalShopping { get; set; }
        public DateTime DtaShopping { get; set; }
        public bool StatusShopping { get; set; }

        public AccountShopping AccountShoppingExecuted { get; set; }

    }
}
