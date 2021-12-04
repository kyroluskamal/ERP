using ERP.Models.COCs;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ERP.Models.Sales
{
    public class SalesInvoices
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string InvoiceBumber { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "bit")]
        public bool SentToClientMethod { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }
        [Required(ErrorMessage = "Required_field")]
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

        public COC COC { get; set; }
        public int? COCId { get; set; }
    }
}
