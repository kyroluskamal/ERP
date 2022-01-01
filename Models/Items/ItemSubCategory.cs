using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class ItemSubCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }
        public ItemMainCategory ItemMainCategory { get; set; }

        public int ItemMainCategoryId { get; set; }
        [NotMapped]
        public string Subdomain { get; set; }
        public ICollection<Item_Per_Subcategory> Item_Per_Subcategory { get; set; }
    }
}
