using ERP.Models.PointsAndCredits.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.PointsAndCredits
{
    public class CreditCharge
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public int CreditAmount { get; set; }

        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }

        public ERP.Models.COC.COC COC { get; set; }
        public int COCId { get; set; }

        public CreditTypes CreditTypes { get; set; }
        public int CreditTypesId { get; set; }
    }
}
