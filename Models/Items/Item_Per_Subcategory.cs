namespace ERP.Models.Items
{
    public class Item_Per_Subcategory
    {
        public int Id { get; set; }
        public ItemSubCategory ItemSubCategory { get; set; }
        public int? ItemSubCategoryId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
