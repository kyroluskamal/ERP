using ERP.Models.COCs;
using ERP.Models.PointsAndCredits.Settings;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        public COC COC { get; set; }
        public int COCId { get; set; }

        public CreditTypes CreditTypes { get; set; }
        public int CreditTypesId { get; set; }
    }
}
