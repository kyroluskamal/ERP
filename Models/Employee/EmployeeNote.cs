using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Employee
{
    public class EmployeeNote
    {
        [Key]
        public int Id { get; set; }
        public string Note { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employees Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
