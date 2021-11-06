﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class ItemVariants
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the name of variant ")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "smallint")]
        public int NotifyLessThan { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal LastPurchasePrice { get; set; }
        [Required]
        [Column(TypeName = "smallint")]
        public int TotalAmountInAllInvetroies { get; set; }
        [Required]
        [Column(TypeName = "smallint")]
        public int ProfitMargin { get; set; }
        [Column(TypeName = "tinyint")]
        public int ProfitMarginType { get; set; }
        [Required]
        public int Barcode { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        [Column(TypeName = "bit")]
        public bool HasWholeSalePrice { get; set; }
        [Column(TypeName = "bit")]
        public bool HasRetailPrice { get; set; }
    }
}
