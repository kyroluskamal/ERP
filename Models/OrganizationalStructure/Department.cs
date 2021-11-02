using ERP.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.OrganizationalStructure
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please, Write the department name")]
        [MaxLength(20)]
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please, an abbreviation for the department")]
        [MaxLength(10)]
        public string Abbreviation { get; set; }
        [ForeignKey(nameof(EmployeesId))]
        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
    }
}
