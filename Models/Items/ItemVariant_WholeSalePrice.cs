using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class ItemVariant_WholeSalePrice
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal WholeSalePrice { get; set; }
        [Column(TypeName = "Money")]
        public decimal MinWholeSalePrice { get; set; }
        [Column(TypeName = "tinyint")]
        public int DiscountAmount { get; set; }
        [Column(TypeName = "tinyint")]
        public int DiscountType { get; set; }
        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
    }
}
