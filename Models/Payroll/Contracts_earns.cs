using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class Contracts_earns
    {
        public int Id { get; set; }

        public Contracts Contracts { get; set; }
        public int ContractsId { get; set; }

        public SalaryEarning SalaryEarning { get; set; }
        public int SalaryEarningId { get; set; }
    }
}
