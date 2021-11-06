using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases.PurphaseRefund
{
    public class Purchase_RefundRequests
    {
        [Required]
        public string CurrentNumber { get; set; }
        public int Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime RequestDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime RefundDate { get; set; }

        [Column(TypeName = "bit")]
        public bool ServiceOrItem { get; set; }
        [Column(TypeName = "bit")]
        public bool HasPymentTerms { get; set; }
        [Column(TypeName = "bit")]
        public bool HasShippingFees { get; set; }
        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }

        [Column(TypeName = "Money")]
        public decimal TotalMoneyIsRefunded { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }
    }
}
