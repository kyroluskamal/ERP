using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.OrganizationalStructure
{
    public class Designation_description
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a designation")]
        public string Description { get; set; }
        [ForeignKey(nameof(DesignationId))]
        public Designation Designation { get; set; }
        public int DesignationId { get; set; }
    }
}
