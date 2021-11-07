using ERP.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales.SalesCommissions
{
    public class Commissions_Per_employee
    {
        public int Id { get; set; }
        public Commissions Commissions { get; set; }
        public int CommissionsId { get; set; }
        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
    }
}
