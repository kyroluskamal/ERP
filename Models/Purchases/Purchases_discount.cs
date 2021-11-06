using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases
{
    public class Purchases_discount
    {
        public int Id { get; set; }
        [Required]
        public int DiscountValue { get; set; }
        public int DiscountType { get; set; }//Percent or vlaue
        public Purchase_invoices Purchase_invoices { get; set; }
        public int Purchase_invoicesId { get; set; }
    }
}
