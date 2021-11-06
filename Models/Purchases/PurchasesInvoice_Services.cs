using ERP.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases
{
    public class PurchasesInvoice_Services
    {
        public int Id { get; set; }
        [Required]
        public int AddedQuantity { get; set; }

        public Services Services { get; set; }
        public int ServicesId { get; set; }
        public Purchase_invoices Purchase_invoices { get; set; }
        public int Purchase_invoicesId { get; set; }
    }
}
