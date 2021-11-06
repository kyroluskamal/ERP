using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.SystemsInErp
{
    public class SystemsInERP
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
