using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Employee.Shifts
{
    [Table(nameof(EmployeeShifts))]
    public class EmployeeShifts
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Name { get; set; }
        [Column(TypeName = "tinyint")]
        public int StandardOrAdvanced { get; set; }
        public ICollection<Employees> Employees { get; set; }
        public ICollection<ShiftsTimeDetails> ShiftsTimeDetails { get; set; }
    }
}
