using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class LoanNotes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a name")]
        public string Notes { get; set; }

        public Loans Loans { get; set; }
        public int LoansId { get; set; }
    }
}
