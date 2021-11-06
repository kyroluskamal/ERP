using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.OrganizationalStructure
{
    public class EmployeeTypes_desc
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a description")]
        public string Description { get; set; }
        [ForeignKey(nameof(EmployeeTypesId))]
        public EmployeeType EmployeeTypes { get; set; }
        public int EmployeeTypesId { get; set; }
    }
}
