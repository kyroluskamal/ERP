using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases.PurphaseRefund
{
    public class RefundsStatus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, add a status")]
        [MaxLength(30)]
        public string Status { get; set; }
        public Purchase_RefundRequests Purchase_RefundRequests { get; set; }
        public int Purchase_RefundRequestsId { get; set; }
    }
}
