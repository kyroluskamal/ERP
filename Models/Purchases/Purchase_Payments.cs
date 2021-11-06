using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases
{
    public class Purchase_Payments
    {
        public int Id { get; set; }

        public PurchasePaymentMethods PurchasePaymentMethods { get; set; }
        public int PurchasePaymentMethodsId { get; set; }

        public Purchase_invoices Purchase_invoices { get; set; }
        public int Purchase_invoicesId { get; set; }
    }
}
