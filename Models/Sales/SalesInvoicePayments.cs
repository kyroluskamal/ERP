using ERP.Models.Employee;
using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class SalesInvoicePayments
    {
        public int Id { get; set; }
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "bit")]
        public bool HasDetails { get; set; }
        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }
        [Column(TypeName = "bit")]
        public bool HasAttachment { get; set; }

        [ForeignKey(nameof(CollectedBy_EmpId))]
        public Employees Employees { get; set; }
        public int CollectedBy_EmpId { get; set; }

        [ForeignKey(nameof(PaymentStatusId))]
        public SalesInvoice_PaymentStatus SalesInvoice_PaymentStatus { get; set; }
        public int PaymentStatusId { get; set; }

        public PaymentMethods PaymentMethods { get; set; }
        public int PaymentMethodsId { get; set; }

        public string Currency { get; set; }
        public int CurrencyId { get; set; }
    }
}
