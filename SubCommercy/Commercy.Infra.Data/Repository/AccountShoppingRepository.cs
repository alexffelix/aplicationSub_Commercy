using Commercy.Infra.Data.Context;
using CommercyDomain.Entities;
using CommercyDomain.Interface;
using Equinox.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercy.Infra.Data.Repository
{
    public class AccountShoppingRepository : Repository<AccountShopping>, IAccountShoppingRepository
    {
        public AccountShoppingRepository(CommercyContext context)
            : base(context)
        {

        }
    }
}
