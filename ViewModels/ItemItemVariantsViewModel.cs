using ERP.Models.Items;

namespace ERP.ViewModels
{
    public class ItemItemVariantsViewModel
    {
        public Item Item { get; set; }
        public ItemVariants[] ItemVariants { get; set; }
    }
}
