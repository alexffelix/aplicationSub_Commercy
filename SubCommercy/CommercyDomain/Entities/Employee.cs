using CommercyDomain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercyDomain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DtaContract { get; set; }
    }
}
