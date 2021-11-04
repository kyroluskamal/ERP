using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Inventory
{
    public class Items_withEpire
    {
        public int Id { get; set; }
        public Inventory Inventory { get; set; }
        public int InventoryId { get; set; }
        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
        [Required]
        public int Amount { get; set; }

        [Column(TypeName = "tinyint")]
        [MaxLength(2)]
        public int ExpireMonth { get; set; }
        [Column(TypeName = "smallint")]
        [MaxLength(4)]
        public int ExoireDate { get; set; }
    }
}
