using ERP.Models.SystemsInErp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.NumberingSystem
{
    public class NumberingSettings
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string CurrentNumber { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public int NumberingStyle { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "tinyint")]
        public int MinimumNubmerOfdigits { get; set; }

        [Column(TypeName = "bit")]
        public bool HasPrefix { get; set; }
        [Column(TypeName = "bit")]
        public bool IsRequired { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string StartNumbering { get; set; }

        public SystemsInERP SystemsInERP { get; set; }
        public int SystemsInERPId { get; set; }
    }
}
