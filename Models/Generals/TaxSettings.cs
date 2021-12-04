using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Generals
{
    public class TaxSettings
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "tinyint")]
        public int Percent { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "tinyint")]
        public int InclusiveOrExclusive { get; set; }
    }
}
