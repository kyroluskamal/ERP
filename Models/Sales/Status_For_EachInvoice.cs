using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class Status_For_EachInvoice
    {
        public int Id { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int SalesInvoicesId { get; set; }

        public SalesInvoicesStatus SalesInvoicesStatus { get; set; }
        public int SalesInvoicesStatusId { get; set; }
    }
}
