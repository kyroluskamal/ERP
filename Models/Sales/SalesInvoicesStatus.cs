using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class SalesInvoicesStatus
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Status { get; set; }
    }
}
