using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.OrganizationalStructure
{
    public class Designation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, Write a designation")]
        [MaxLength(20)]
        public string DesignationName { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
