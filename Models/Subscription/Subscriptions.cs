using ERP.Models.COCs;
using ERP.Models.Generals;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ERP.Models.Subscription
{
    public class Subscriptions
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string CurrentNumber { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }

        [Column(TypeName = "tinyint")]
        public int GenerateEvery { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreationDate { get; set; }

        public int Occurrences { get; set; }
        public int IssueInvoiceBefore { get; set; }
        public int PaymentTerms { get; set; } //(payAfter)

        [Column(TypeName = "bit")]
        public bool DisplayDateFromAndTo { get; set; }
        [Column(TypeName = "bit")]
        public bool EnableAutomaticPayment { get; set; }
        [Column(TypeName = "bit")]
        public bool SendViaEmail { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }
        [Column(TypeName = "bit")]
        public bool HasTerms { get; set; }

        public COC COC { get; set; }
        public int COCId { get; set; }

        public Currency Currency { get; set; }
        public int? CurrencyId { get; set; }
    }
}
