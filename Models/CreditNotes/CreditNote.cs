using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CreditNotes
{
    public class CreditNote
    {
        public int Id { get; set; }

        [Required]
        public string CreditNoteNumner { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreationDate { get; set; }

        [Column(TypeName = "bit")]
        public bool IsConfirmed { get; set; }
        [Column(TypeName = "bit")]
        public bool ServiceOrItem { get; set; }
        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }
        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }

        [Required]
        public int TotalAmount { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }
        public int UserId { get; set; }

        public EmailsTemplates EmailsTemplates { get; set; }
        public int EmailsTemplatesId { get; set; }
    }
}
