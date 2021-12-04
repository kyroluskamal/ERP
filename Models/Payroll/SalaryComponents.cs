using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class SalaryComponents
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool DetuctionOrEarning { get; set; }
        [Column(TypeName = "bit")]
        public bool AmountOrFormula { get; set; }
    }
}
