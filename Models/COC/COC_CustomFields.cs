using ERP.Models.CutomFields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.COC
{
    public class COC_CustomFields
    {
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }

        public COC COC { get; set; }
        public int COCId { get; set; }
        public Fields_Per_Service Fields_Per_Service { get; set; }
        public int Fields_Per_ServiceId { get; set; }
    }
}
