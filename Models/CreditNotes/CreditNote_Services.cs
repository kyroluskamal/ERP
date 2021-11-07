using ERP.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CreditNotes
{
    public class CreditNote_Services
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal ServicePrice { get; set; }
        public Services Services { get; set; }
        public int ServicesId { get; set; }

        public CreditNote CreditNote { get; set; }
        public int CreditNoteId { get; set; }
    }
}
