using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Employee
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Middle name is required")]
        public string MiddleName { get; set; }
        [EmailAddress]
        public string PersonalEmail { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Employee gender is required ")]
        public bool Gender { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime JoinDate { get; set; }

        public byte[] ProfileIMage { get; set; }
        public ICollection<EmployeeImages> PaperImages { get; set; }
        public ICollection<EmployeeAddress> EmpAddress { get; set; }
    }
}
