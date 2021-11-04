using ERP.Models.CutomFields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Items
{
    public class Items_CustomFields
    {
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }

        public Item Item { get; set; }
        public int ItemId { get; set; }
        
        public Fields_Per_Service Fields_Per_Service { get; set; }
        public int Fields_Per_ServiceId { get; set; }
    }
}
