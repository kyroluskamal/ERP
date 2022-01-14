using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class ItemBrands
    {
        public Item Item { get; set; }
        [Key, Column(Order = 0)]
        public int ItemId { get; set; }
        public Brands Brands { get; set; }
        [Key, Column(Order = 1)]
        public int? BrandsId { get; set; }
        public ICollection<ItemVariants> ItemVariants { get; set; }
        
    }
}
