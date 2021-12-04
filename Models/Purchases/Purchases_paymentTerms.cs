using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases
{
    public class Purchases_paymentTerms
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int Value { get; set; }
        public Purchase_invoices Purchase_invoices { get; set; }
        public int Purchase_invoicesId { get; set; }
    }
}
