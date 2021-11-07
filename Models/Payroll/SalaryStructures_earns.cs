using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class SalaryStructures_earns
    {
        public int Id { get; set; }
        public SalaryStructures SalaryStructures { get; set; }
        public int SalaryStructuresId { get; set; }

        public SalaryEarning SalaryEarning { get; set; }
        public int SalaryEarningId { get; set; }
    }
}
