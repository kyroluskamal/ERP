using ERP.Models.Items;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Inventory
{
    public class Items_withEpire
    {
        public int Id { get; set; }
        public Inventories Inventory { get; set; }
        public int InventoryId { get; set; }
        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int Amount { get; set; }

        [Column(TypeName = "tinyint")]
        [MaxLength(2, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public int ExpireMonth { get; set; }
        [Column(TypeName = "smallint")]
        [MaxLength(4, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public int ExoireDate { get; set; }
    }
}
