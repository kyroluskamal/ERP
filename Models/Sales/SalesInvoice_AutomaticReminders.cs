using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class SalesInvoice_AutomaticReminders
    {
        public int Id { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int SalesInvoicesId { get; set; }

        public AutomaticReminders AutomaticReminders { get; set; }
        public int AutomaticRemindersId { get; set; }
    }
}
