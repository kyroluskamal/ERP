using ERP.Models.Employee;
using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class Payslips
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime PostingDate { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "Money")]
        public decimal GrossPay { get; set; }
        [Column(TypeName = "Money")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName = "Money")]
        public decimal NetPay { get; set; }

        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }

        public Currency Currency { get; set; }
        public int? CurrencyId { get; set; }
    }
}
