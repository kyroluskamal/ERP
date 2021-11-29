using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.COCs
{
    public class Business_COC
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string BusinessName { get; set; }
        public string BusinessPhone { get; set; }
        public string TaxRecordId { get; set; }
        public string CR { get; set; }//السجل التجاري
        [ForeignKey(nameof(COCId))]
        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
