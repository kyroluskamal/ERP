using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class SalesInvoices_Attachments
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public byte[] Attachments { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int SalesInvoicesId { get; set; }
    }
}
