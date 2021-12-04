using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class Item
    {
        public int Id { get; set; }
        public int DefaultInventoryId { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }
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
        
        [Required(ErrorMessage = "Required_field")]
        public int AddByUserId { get; set; }

    }
}
