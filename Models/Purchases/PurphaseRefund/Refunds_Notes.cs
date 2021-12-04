using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases.PurphaseRefund
{
    public class Refunds_Notes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Notes { get; set; }

        public Purchase_RefundRequests Purchase_RefundRequests { get; set; }
        public int Purchase_RefundRequestId { get; set; }
    }
}
