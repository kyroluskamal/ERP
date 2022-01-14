using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class ItemVariants
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(300)]
        public string VariantName { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "smallint")]
        public int NotifyLessThan { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int  CurrentNoInWarehouse { get; set; }
        [Column(TypeName = "Money")]
        public decimal? LastPurchasePrice { get; set; }
        [Column(TypeName = "smallint")]
        public int? TotalAmountInAllInvetroies { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "smallint")]
        public int ProfitMargin { get; set; }
        [Column(TypeName = "tinyint")]
        public int ProfitMarginType { get; set; }
        public string Barcode { get; set; }
        public string GlobalBarcode { get; set; }
        [ForeignKey("ItemId, BrandsId")]
        public ItemBrands ItemBrands { get; set; }
        public int ItemId { get; set; }
        public int BrandsId { get; set; }
        public string ItemSKU { get; set; }
        public string ItemSKUStructure { get; set; }//المفاتيح مربوطة ب(-)
        [Column(TypeName = "bit")]
        public bool HasWholeSalePrice { get; set; }
        [Column(TypeName = "bit")]
        public bool HasRetailPrice { get; set; }
        public ItemVariant_WholeSalePrice ItemVariant_WholeSalePrice { get; set; }
        public ItemsVariant_RetailPrice ItemsVariant_RetailPrice { get; set; }
        public ICollection<ItemSKUkeys_Per_ItemVariants> ItemSKUkeys_Per_ItemVariants { get; set; }
        [NotMapped]
        public decimal RetailPrice { get; set; }
        [NotMapped]
        public decimal WholeSalePrice { get; set; }
        [NotMapped]
        public  ItemSKUKeys ItemSKUKeys { get; set; }
    }
}
