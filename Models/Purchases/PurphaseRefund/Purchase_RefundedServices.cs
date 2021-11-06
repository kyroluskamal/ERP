using ERP.Models.Inventory;
using ERP.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases.PurphaseRefund
{
    public class Purchase_RefundedServices
    {
        public int Id { get; set; }
        [Required]
        public int RefundedQuantity { get; set; }

        public Services Services { get; set; }
        public int ServicesId { get; set; }
        public Purchase_RefundRequests Purchase_RefundRequests { get; set; }
        public int Purchase_RefundRequestsId { get; set; }
    }
}
