using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class Payslips_Earns
    {
        public int Id { get; set; }
        public Payslips Payslips { get; set; }
        public int PayslipsId { get; set; }

        public SalaryEarning SalaryEarning { get; set; }
        public int SalaryEarningId { get; set; }
    }
}
