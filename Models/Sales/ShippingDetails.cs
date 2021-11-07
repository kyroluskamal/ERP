using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class ShippingDetails
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal ShippingFees { get; set; }

        [Column(TypeName = "tinyint")]
        public int ShowingInInvoiceOptions { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int SalesInvoicesId { get; set; }
    }
}
