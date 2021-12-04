using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class ContractDuration
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        [Column(TypeName = "bit")]
        public bool MonthOrYear { get; set; }

        public Contract_Per_Emp Contract_Per_Emp { get; set; }
        public int Contract_Per_EmpId { get; set; }
    }
}
