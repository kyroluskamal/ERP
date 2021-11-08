using ERP.Models.Inventory;
using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class ItemsInSalesInvoices
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal SubtotalPerItem { get; set; }

        [Required]
        public string Decriptions { get; set; }

        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int? SalesInvoicesId { get; set; }

        public Inventories Inventories { get; set; }
        public int? InventoriesId { get; set; }
    }
}
