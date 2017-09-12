using Commercy.Infra.Data.Context;
using CommercyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commercy.Infra.Data.Data
{
    public class DbInicializer
    {
        public static void Initialize(CommercyContext context)
        {
            context.Database.EnsureCreated();
            if (context.Employee.Any())
            {
                return;  //O banco foi inicializado
            }
            var employees = new Employee[]
            {
            new Employee{EmployeeName="Carlos",DtaContract=DateTime.Parse("2015-09-01")},
            };
            foreach (Employee s in employees)
            {
                context.Employee.Add(s);
            }
            context.SaveChanges();
        }
    }
}
