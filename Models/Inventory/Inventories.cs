using ERP.Models.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Inventory
{
    public class Inventories
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a name for the inventory")]
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }
        public string Telephone { get; set; }
        public string Notes { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool IsMainInventory { get; set; }

        [ForeignKey(nameof(AddedBy_EmpId))]
        public Employees Employees { get; set; }
        public int AddedBy_EmpId { get; set; }
    }
}
