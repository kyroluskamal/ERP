﻿using ERP.Models.CutomFields;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Items
{
    public class Items_CustomFields
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Value { get; set; }

        public Item Item { get; set; }
        public int ItemId { get; set; }

        public Fields_Per_Service Fields_Per_Service { get; set; }
        public int Fields_Per_ServiceId { get; set; }
    }
}
