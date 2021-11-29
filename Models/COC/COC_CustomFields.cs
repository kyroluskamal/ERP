using ERP.Models.CutomFields;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models.COCs
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
