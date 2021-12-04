using ERP.Models.Inventory;
using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases
{
    public class Items_In_PurchaseInvoice
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int AddedQuantity { get; set; }

        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
        public Purchase_invoices Purchase_invoices { get; set; }
        public int Purchase_invoicesId { get; set; }

        public Inventories Inventories { get; set; }
        public int InventoriesId { get; set; }
    }
}
