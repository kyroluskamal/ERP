using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.PointsAndCredits.Settings
{
    public class CreditTypes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string CreditTypeName { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool AllowDecimal { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Unit { get; set; }
    }
}
