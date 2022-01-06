using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class Item_per_MainCategory_Per_SubCategory
    {
        [ForeignKey("ItemMainCategoryId, ItemId")]
        public Item_Per_MainCategory Item_Per_MainCategory { get; set; }
        public int ItemMainCategoryId { get; set; }
        public int ItemId { get; set; }
        public ItemSubCategory ItemSubCategory { get; set; }
        public int? ItemSubCategoryId { get; set; }
    }
}
