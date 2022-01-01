using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class ItemVariants
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "smallint")]
        public int NotifyLessThan { get; set; }
        [Column(TypeName = "Money")]
        public decimal? LastPurchasePrice { get; set; }
        [Column(TypeName = "smallint")]
        public int? TotalAmountInAllInvetroies { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "smallint")]
        public int ProfitMargin { get; set; }
        [Column(TypeName = "tinyint")]
        public int ProfitMarginType { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int Barcode { get; set; }
        public string ItemSKU { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        [Column(TypeName = "bit")]
        public bool HasWholeSalePrice { get; set; }
        [Column(TypeName = "bit")]
        public bool HasRetailPrice { get; set; }
        public virtual ItemVariant_WholeSalePrice ItemVariant_WholeSalePrice { get; set; }
        public virtual ItemsVariant_RetailPrice ItemsVariant_RetailPrice { get; set; }
    }
}
