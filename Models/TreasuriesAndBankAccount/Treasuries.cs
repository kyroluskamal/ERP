using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.TreasuriesAndBankAccount
{
    public class Treasuries
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You need to write a name for your treasury")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
