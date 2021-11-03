using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CutomFields
{
    public class Fields_layout
    {
        public int Id { get; set; }
        [Column(TypeName = "tinyint")]
        public int Size { get; set; }
        public bool ShowInNewLine { get; set; }
        public bool HideField { get; set; }

        public Fields_validation_Foreach_Service Fields_validation_Foreach_Service { get; set; }
        public int Fields_validation_Foreach_ServiceId { get; set; }
    }
}
