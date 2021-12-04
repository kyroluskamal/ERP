using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases
{
    public class Purchases_Deposits
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int DepositsValue { get; set; }
        public int DepositsType { get; set; }//Percent or vlaue
        public Purchase_invoices Purchase_invoices { get; set; }
        public int Purchase_invoicesId { get; set; }
    }
}
