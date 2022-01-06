using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class Item_Per_MainCategory
    {
        public ItemMainCategory ItemMainCategory { get; set; }
        [Key, Column(Order = 0)]
        public int ItemMainCategoryId { get; set; }
        public Item Item { get; set; }
        [Key, Column(Order = 1)]
        public int ItemId { get; set; }
    }
}
