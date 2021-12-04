﻿using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Items
{
    public class ItemDescription
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Description { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
