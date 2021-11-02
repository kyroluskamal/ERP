using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.TreasuriesAndBankAccount
{
    public class Treasury_description
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public Treasuries Treasuries { get; set; }
        public int TreasuryId { get; set; }
    }
}
