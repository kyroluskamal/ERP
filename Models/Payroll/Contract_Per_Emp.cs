using ERP.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class Contract_Per_Emp
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime JoinDate { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ContractSignDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EndOfTestPeriodDate { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool DurationOrEndDate { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }

        public Contracts Contracts { get; set; }
        public int ContractsId { get; set; }

        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
    }
}
