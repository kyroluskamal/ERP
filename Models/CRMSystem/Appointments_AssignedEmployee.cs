using ERP.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CRMSystem
{
    public class Appointments_AssignedEmployee
    {
        public int Id { get; set; }
        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
        public Appointments Appointments { get; set; }
        public int AppointmentsId { get; set; }
    }
}
