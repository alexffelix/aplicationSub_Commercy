using CommercyDomain.Entities;
using CommercyDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercyDomain.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
