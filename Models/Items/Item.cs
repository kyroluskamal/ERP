using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "bit")]
        public bool HasExpire { get; set; }
        [Column(TypeName = "bit")]
        public bool IsOnline { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
        [Column(TypeName = "bit")]
        public bool HasSpecialOffer { get; set; }
        [Column(TypeName = "bit")]
        public bool HasNote { get; set; }
        public int ItemSKU { get; set; }
        [Required]
        public int AddByUserId { get; set; }
        
    }
}
