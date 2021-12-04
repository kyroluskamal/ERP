using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CreditNotes
{
    public class CreditNote_Attachments
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public byte[] Attachments { get; set; }

        public CreditNote CreditNote { get; set; }
        public int CreditNoteId { get; set; }
    }
}
