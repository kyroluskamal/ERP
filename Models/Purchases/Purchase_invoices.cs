using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Purchases
{
    public class Purchase_invoices
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public string CurrentNumber { get; set; }

        [Column(TypeName = "bit")]
        public bool HasPymentTerms { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDiscount { get; set; }
        [Column(TypeName = "bit")]
        public bool HasShippingFees { get; set; }
        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }
        [Column(TypeName = "bit")]
        public bool IsRecieved { get; set; }
        [Column(TypeName = "bit")]
        public bool IsPartiallyPaid { get; set; }
        [Column(TypeName = "bit")]
        public bool IsAlreadyPaid { get; set; }
        [Column(TypeName = "bit")]
        public bool ServiceOrItem { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDeposits { get; set; }
        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }

        public string Currency { get; set; }
        public int? CurrencyId { get; set; }
    }
}
