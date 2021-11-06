using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Employee
{
    [Table("PaperImages")]
    public class EmployeePaperImages
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to add one image at least")]
        public byte[] Image { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employees Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
