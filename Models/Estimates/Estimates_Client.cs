using ERP.Models.COCs;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Estimates
{
    public class Estimates_Client
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ValidFromDate { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ValidToDate { get; set; }

        public Estimate Estimate { get; set; }
        public int? EstimateId { get; set; }

        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
