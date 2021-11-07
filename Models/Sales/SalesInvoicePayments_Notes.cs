using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class SalesInvoicePayments_Notes
    {
        public int Id { get; set; }

        [Required]
        public string Notes { get; set; }
        public SalesInvoicePayments SalesInvoicePayments { get; set; }
        public int SalesInvoicePaymentsID { get; set; }
    }
}
