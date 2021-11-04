using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Checks
{
    public class PayableCheck_Attachments
    {
        public int Id { get; set; }
        [Required]
        public byte[] Attachments { get; set; }

        public PayableCheck PayableCheck { get; set; }
        public int PayableCheckId { get; set; }
    }
}
