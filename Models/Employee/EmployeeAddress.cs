using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Employee
{
    public class EmployeeAddress
    {
        [Key]
        public int Id { get; set; }
        public string BuildingNo { get; set; }
        public string FlatNo { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string AddressLine_1 { get; set; }
        public string AddressLine_2 { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "bit")]
        public bool PermanentOrPresent { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employees Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
