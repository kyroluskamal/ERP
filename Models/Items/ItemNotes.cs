﻿using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Items
{
    public class ItemNotes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a note")]
        public string Notes { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
