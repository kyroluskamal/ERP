using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class SalesInvoice_PaymentStatus
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string StatusName { get; set; }
    }
}
