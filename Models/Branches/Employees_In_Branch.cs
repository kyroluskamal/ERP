using ERP.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Branches
{
    public class Employees_In_Branch
    {
        [ForeignKey(nameof(BranchId))]
        public BusinessBranches BusinessBranches{ get; set; }
        public int BranchId{ get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employees Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
