using ERP.Models.Supplier;

namespace ERP.Models.Items
{
    public class ItemSuppliers
    {
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public Suppliers Suppliers { get; set; }
        public int SuppliersId { get; set; }
    }
}
