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
        [Required(ErrorMessage = "Please, write a description")]
        [MaxLength(30)]
        public string CreditTypeName { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool AllowDecimal { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
        [Required(ErrorMessage = "Please, write a description")]
        [MaxLength(30)]
        public string Unit { get; set; }
    }
}
