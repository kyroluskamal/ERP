using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class SalesInvoices
    {
        public int Id { get; set; }
        [Required]
        public string InvoiceBumber { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool SentToClientMethod { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "Date")]
        public DateTime IssueDate { get; set; }
        [Column(TypeName = "smallint")]
        public int PaymentDue { get; set; }
        [Column(TypeName = "bit")]
        public bool IsPaid { get; set; }
        [Column(TypeName = "bit")]
        public bool HasSubscription { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDiscount { get; set; }
        [Column(TypeName = "bit")]
        public bool HasCustomFields { get; set; }
        [Column(TypeName = "bit")]
        public bool HasShippingDetails { get; set; }
        [Column(TypeName = "Money")]
        public decimal TotalValue { get; set; }
        [Column(TypeName = "bit")]
        public bool ServiceOrItem { get; set; } //Service or product

        [ForeignKey(nameof(CreatedBy_UserId))]
        public ApplicationUser ApplicationUser { get; set; }
        public int CreatedBy_UserId { get; set; }

        public ERP.Models.COC.COC COC { get; set; }
        public int? COCId { get; set; }
    }
}
