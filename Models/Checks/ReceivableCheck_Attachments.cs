using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Checks
{
    public class ReceivableCheck_Attachments
    {
        public int Id { get; set; }
        [Required]
        public byte[] Attachments { get; set; }

        public ReceivableCheck ReceivableCheck { get; set; }
        public int ReceivableCheckId { get; set; }
    }
}
