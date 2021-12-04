using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.OrganizationalStructure
{
    public class EmployeeType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(20, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string EmployeeTypeName { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
    }
}
