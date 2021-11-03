using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CutomFields
{
    public class Fields_Properties
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Label { get; set; }
        //دي الحاجات اللى هتتكتب وتظهر لما نعمل هوفر على علامة الاستفاهم
        public string Hint { get; set; }
        [Required]
        public string InitialValue { get; set; }
        [Required]
        [MaxLength(30)]
        public string Placeholder { get; set; }
        public bool EnableAutocomplete { get; set; }
        public bool HasChoices { get; set; }
        public bool EnableQuickSearch { get; set; }
        public Fields_validation_Foreach_Service Fields_validation_Foreach_Service { get; set; }
        public int Fields_validation_Foreach_ServiceId { get; set; }
    }
}
