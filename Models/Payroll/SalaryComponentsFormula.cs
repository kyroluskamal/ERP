using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class SalaryComponentsFormula
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Formula { get; set; }
        public SalaryComponents SalaryComponents { get; set; }
        public int SalaryComponentsId { get; set; }
    }
}
