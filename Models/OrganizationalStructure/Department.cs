using ERP.Models.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.OrganizationalStructure
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(20, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string DepartmentName { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(10, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Abbreviation { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }

        [ForeignKey(nameof(EmployeesId))]
        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
    }
}
