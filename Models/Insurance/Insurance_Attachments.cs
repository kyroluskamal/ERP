using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Insurance
{
    public class Insurance_Attachments
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public byte[] Attachments { get; set; }
        public InsuranceAgent InsuranceAgent { get; set; }
        public int InsuranceAgentId { get; set; }
    }
}
