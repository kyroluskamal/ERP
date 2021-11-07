using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class SalaryStructures_Deduction
    {
        public int Id { get; set; }
        public SalaryStructures SalaryStructures { get; set; }
        public int SalaryStructuresId { get; set; }

        public SalaryDetuction SalaryDetuction { get; set; }
        public int SalaryDetuctionId { get; set; }
    }
}
