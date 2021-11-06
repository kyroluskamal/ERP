using ERP.Models.Items;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Inventory
{
    public class Items_NoEpire
    {
        public int Id { get; set; }
        public Inventories Inventory { get; set; }
        public int InventoryId { get; set; }
        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
