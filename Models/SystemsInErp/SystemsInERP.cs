using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.SystemsInErp
{
    public class SystemsInERP
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
