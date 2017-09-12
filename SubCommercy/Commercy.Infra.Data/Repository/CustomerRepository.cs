using Commercy.Infra.Data.Context;
using CommercyDomain.Entities;
using CommercyDomain.Interface;
using Equinox.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercy.Infra.Data.Repository
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CommercyContext context)
            : base(context)
        {

        }
    }
}
