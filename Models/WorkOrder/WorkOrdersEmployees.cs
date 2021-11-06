using ERP.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.WorkOrder
{
    public class WorkOrdersEmployees
    {
        public int Id { get; set; }
        public WorkOrders WorkOrders { get; set; }
        public int WorkOrdersId { get; set; }

        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
    }
}
