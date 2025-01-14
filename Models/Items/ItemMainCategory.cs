﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class ItemMainCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string MainCatName { get; set; }
        [NotMapped]
        public string Subdomain { get; set; }
        public ICollection<ItemSubCategory> ItemSubCategory { get; set; }
        public ICollection<Item_Per_MainCategory> Item_Per_Subcategory { get; set; }
    }
}
