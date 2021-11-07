using ERP.Models.CreditNotes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class RefundedServices
    {
        public int Id { get; set; }

        [Required]
        public string Reason { get; set; }

        public ServicesInSalesInvices ServicesInSalesInvices { get; set; }
        public int ServicesInSalesInvicesId { get; set; }

        public CreditNote_Services CreditNote_Services { get; set; }
        public int CreditNote_ServicesId { get; set; }
    }
}
