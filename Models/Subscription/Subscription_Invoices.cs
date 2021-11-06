using ERP.Models.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Subscription
{
    public class Subscription_Invoices
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FromDate { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ToDate { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int SalesInvoicesId { get; set; }
        public Subscriptions Subscriptions { get; set; }
        public int SubscriptionsId { get; set; }
    }
}
