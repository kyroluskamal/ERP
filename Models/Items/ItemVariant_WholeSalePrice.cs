using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class ItemVariant_WholeSalePrice
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal WholeSalePrice { get; set; }
        [Column(TypeName = "Money")]
        public decimal MinWholeSalePrice { get; set; }
        [Column(TypeName = "tinyint")]
        public int DiscountAmount { get; set; }
        [Column(TypeName = "tinyint")]
        public int DiscountType { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateModified { get; set; }
        public string ModifiedBy_UserName { get; set; }
        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
    }
}
