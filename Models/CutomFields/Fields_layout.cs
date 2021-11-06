using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.CutomFields
{
    public class Fields_layout
    {
        public int Id { get; set; }
        [Column(TypeName = "tinyint")]
        public int Size { get; set; }
        [Column(TypeName = "bit")]
        public bool ShowInNewLine { get; set; }
        [Column(TypeName = "bit")]
        public bool HideField { get; set; }

        public Fields_validation_Foreach_Service Fields_validation_Foreach_Service { get; set; }
        public int Fields_validation_Foreach_ServiceId { get; set; }
    }
}
