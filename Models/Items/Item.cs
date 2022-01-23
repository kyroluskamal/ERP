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
        public bool HasSpecialOffer { get; set; }//not implemented yet
        [Column(TypeName = "bit")]
        public bool HasNote { get; set; }//not yet
        [Column(TypeName = "bit")]
        public bool HasSKU_number { get; set; }//Should be removed
        [Column(TypeName = "bit")]
        public bool HasInternalNote { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateCreated { get; set; }
        public string ProductImage { get; set; }
        [ForeignKey(nameof(AddedBy_UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int? AddedBy_UserId { get; set; }
        public string AddedBy_UserName { get; set; }
        public virtual ItemNotes ItemNotes { get; set; }
        public virtual InternalNotes InternalNotes { get; set; }
        public virtual ItemDescription ItemDescription { get; set; }
        public ICollection<Item_Units> Item_Units { get; set; }
        public ICollection<ItemBrands> ItemBrands { get; set; }
        public ICollection<Item_Per_MainCategory> Item_Per_MainCategory { get; set; }
        public ICollection<ItemSuppliers> ItemSuppliers { get; set; }
        [NotMapped]
        public string NotesForClients { get; set; }
        [NotMapped]
        public string InternalNote { get; set; }
        [NotMapped]
        public string Description { get; set; }
        [NotMapped]
        public int[] SubCatsId { get; set; }
        [NotMapped]
        public int[] BrandsIds { get; set; }
        [NotMapped]
        public int[] UnitsIds { get; set; }
        [NotMapped]
        public int[] SuppliersIds { get; set; }
        [NotMapped]
        public ItemSKUKeys[] ItemSKUKeys { get; set; }
    }
}
