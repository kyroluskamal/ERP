using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Items
{
    public class Item
    {
        public int Id { get; set; }
        public int DefaultInventoryId { get; set; }
        [Required(ErrorMessage ="Please, Write the item's name")]
        [MaxLength(30)]
        public string Name { get; set; }
        public bool HasExpire { get; set; }
        public bool IsOnline { get; set; }
        public bool HasDescription { get; set; }
        public bool HasSpecialOffer { get; set; }
        public bool HasNote { get; set; }
        public int ItemSKU { get; set; }
        [Required]
        public int AddByUserId { get; set; }
        
    }
}
