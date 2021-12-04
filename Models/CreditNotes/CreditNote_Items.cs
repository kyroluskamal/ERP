using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CreditNotes
{
    public class CreditNote_Items
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal ItemPrice { get; set; }
        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }

        public CreditNote CreditNote { get; set; }
        public int CreditNoteId { get; set; }
    }
}
