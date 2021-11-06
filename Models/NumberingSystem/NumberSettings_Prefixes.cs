using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.NumberingSystem
{
    public class NumberSettings_Prefixes
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Prefix { get; set; }
        [Column(TypeName = "tinyint")]
        public int Mode { get; set; }
        [Required]
        [MaxLength(30)]
        public string NextNumberPerPrefix { get; set; }

        public NumberingSettings NumberingSettings { get; set; }
        public int NumberingSettingsId { get; set; }
    }
}
