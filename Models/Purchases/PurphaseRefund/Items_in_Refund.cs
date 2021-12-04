using ERP.Models.Inventory;
using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases.PurphaseRefund
{
    public class Items_in_Refund
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int RefundedQuantity { get; set; }

        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
        public Purchase_RefundRequests Purchase_RefundRequests { get; set; }
        public int Purchase_RefundRequestsId { get; set; }

        public Inventories Inventories { get; set; }
        public int InventoriesId { get; set; }
    }
}
