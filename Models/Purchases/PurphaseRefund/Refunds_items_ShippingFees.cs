using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases.PurphaseRefund
{
    public class Refunds_items_ShippingFees
    {
        public int Id { get; set; }
        [Required]
        public int ShippingFees { get; set; }
        public Purchase_RefundRequests Purchase_RefundRequests { get; set; }
        public int Purchase_RefundRequestsId { get; set; }
    }
}
