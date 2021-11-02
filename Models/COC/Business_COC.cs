using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.COC
{
    public class Business_COC
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You must enter the buisness name")]
        public string BusinessName { get; set; }
        public string BusinessPhone { get; set; }
        public string TaxId { get; set; }
        public string CR { get; set; }
        [ForeignKey(nameof(COCId))]
        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
