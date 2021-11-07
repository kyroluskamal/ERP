using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class SalaryEarning
    {
        public int Id { get; set; }
        public SalaryComponents SalaryComponents { get; set; }
        public int SalaryComponentsId { get; set; }
    }
}
