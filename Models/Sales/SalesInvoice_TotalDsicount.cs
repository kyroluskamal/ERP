using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class SalesInvoice_TotalDsicount
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal TotalDiscount { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "bit")]
        public bool DiscountType { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int SalesInvoicesId { get; set; }
    }
}
