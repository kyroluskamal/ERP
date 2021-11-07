using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class Terms_Per_Invoice
    {
        public int Id { get; set; }
        [Required]
        public int TaxValue { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int SalesInvoicesId { get; set; }

        public SalesTerms SalesTerms { get; set; }
        public int SalesTermsId { get; set; }
    }
}
