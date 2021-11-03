using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Generals
{
    public class TaxSettings
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please, write the name of the tax")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, write the tax value in percent")]
        [Column(TypeName ="tinyint")]
        public int Percent { get; set; }
        [Required(ErrorMessage ="Please, choose the type of the tax value")]
        [Column(TypeName ="bit")]
        public int InclusiveOrExclusive { get; set; }
    }
}
