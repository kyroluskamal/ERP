using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.OrganizationalStructure
{
    public class Department_description
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Description { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
