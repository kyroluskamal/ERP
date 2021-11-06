using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.CutomFields
{
    public class MinAndMaxDate
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime MinDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime MaxDate { get; set; }

        public Fields_validation_Foreach_Service Fields_validation_Foreach_Service { get; set; }
        public int Fields_validation_Foreach_ServiceId { get; set; }
    }
}
