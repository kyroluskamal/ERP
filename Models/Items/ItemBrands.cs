using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Items
{
    public class ItemBrands
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public Brands Brands { get; set; }
        public int? BrandsId { get; set; }
    }
}
