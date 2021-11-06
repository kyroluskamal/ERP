using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.CutomFields
{
    public class MinAndMaxNumbers
    {
        public int Id { get; set; }
        [Column(TypeName = "smallint")]
        public int MinNumber { get; set; }
        [Column(TypeName = "smallint")]
        public int MaxNumber { get; set; }
        [Column(TypeName = "tinyint")]
        //0 = Digit, 1 = Value, -1= type is not applacable
        public int Digit_Value_NotApplicable { get; set; }

        public Fields_validation_Foreach_Service Fields_validation_Foreach_Service { get; set; }
        public int Fields_validation_Foreach_ServiceId { get; set; }
    }
}
