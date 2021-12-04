using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class SalaryComponentsAmount
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        public SalaryComponents SalaryComponents { get; set; }
        public int SalaryComponentsId { get; set; }
    }
}
