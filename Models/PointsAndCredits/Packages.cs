using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.PointsAndCredits
{
    public class Packages
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, Write the name of the package")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Column(TypeName = "bit")]
        public bool PackageType { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Required]
        public int Period { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public int PeriodType { get; set; }
    }
}
