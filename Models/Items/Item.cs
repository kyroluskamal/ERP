using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class Item
    {
        public int Id { get; set; }
        public int DefaultInventoryId { get; set; }
        public string DefaultInventoryName { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string ItemName { get; set; }
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
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateCreated { get; set; }
        [ForeignKey(nameof(AddedBy_UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int? AddedBy_UserId { get; set; } //Not Required temporary
        public string AddedBy_UserName { get; set; }
        public ICollection<ItemVariants> ItemVariants { get; set; }
        public virtual ItemNotes ItemNotes { get; set; }
        public virtual ItemDescription ItemDescription { get; set; }
        public ICollection<Item_Units> Item_Units { get; set; }
        public ICollection<ItemBrands> ItemBrands { get; set; }
        public ICollection<Item_Per_MainCategory> Item_Per_Subcategory { get; set; }
        [NotMapped]
        public string InternalNotes { get; set; }
        [NotMapped]
        public string Description { get; set; }
    }
}
