using ERP.Models.CreditNotes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class RefundedItems
    {
        public int Id { get; set; }

        [Required]
        public string Reason { get; set; }

        public ItemsInSalesInvoices ItemsInSalesInvoices { get; set; }
        public int ItemsInSalesInvoicesId { get; set; }

        public CreditNote_Items CreditNote_Items { get; set; }
        public int CreditNote_ItemsId { get; set; }
    }
}
