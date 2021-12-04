using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CreditNotes
{
    public class CreditNote_Notes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public string Notes { get; set; }

        public CreditNote CreditNote { get; set; }
        public int CreditNoteId { get; set; }
    }
}
