using System.Collections.Generic;

namespace ERP.Models.Items
{
    public class ItemSKUKeys
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public ICollection<ItemSKUkeys_Per_ItemVariants> ItemSKUkeys_Per_ItemVariants { get; set; }
    }
}
