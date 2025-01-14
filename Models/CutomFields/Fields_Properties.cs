﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.CutomFields
{
    public class Fields_Properties
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Label { get; set; }
        //دي الحاجات اللى هتتكتب وتظهر لما نعمل هوفر على علامة الاستفاهم
        public string Hint { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string InitialValue { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Placeholder { get; set; }
        [Column(TypeName = "bit")]
        public bool EnableAutocomplete { get; set; }
        [Column(TypeName = "bit")]
        public bool HasChoices { get; set; }
        [Column(TypeName = "bit")]
        public bool EnableQuickSearch { get; set; }
        public Fields_validation_Foreach_Service Fields_validation_Foreach_Service { get; set; }
        public int Fields_validation_Foreach_ServiceId { get; set; }
    }
}
