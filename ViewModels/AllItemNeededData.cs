using ERP.Models.Items;
using ERP.Models.Supplier;
using System.Collections.Generic;

namespace ERP.ViewModels
{
    public class AllItemNeededData
    {
        public List<Brands> Brands { get; set; }
        public List<Units> Units { get; set; }
        public List<ItemMainCategory> ItemMainCategories { get; set; }
        public List<Suppliers> Suppliers { get; set; }
        public List<ItemSKUKeys> ItemSKUKeys { get; set; }
    }
}
