using ERP.Models.CutomFields;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Employee
{
    public class Employees_customFields
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Value { get; set; }
        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
        public Fields_Per_Service Fields_Per_Service { get; set; }
    }
}
