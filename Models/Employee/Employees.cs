using ERP.Models.Generals;
using ERP.Models.OrganizationalStructure;
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

        [Required(ErrorMessage = "Your first name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Your last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Middle name is required")]
        public string MiddleName { get; set; }

        [EmailAddress]
        public string PersonalEmail { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Employee gender is required ")]
        [Column(TypeName ="tinyint")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime JoinDate { get; set; }

        public byte[] ProfileIMage { get; set; }

        public ICollection<EmployeePaperImages> PaperImages { get; set; }
        public ICollection<EmployeeAddress> EmpAddress { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }
        public int UserId { get; set; }

        
        public Country Country { get; set; }
        public int? CountryId { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public Designation Designation { get; set; }
        public int? DesignationId { get; set; }
        public EmployeeLevel EmployeeLevel { get; set; }
        public int? EmployeeLevelId { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int? EmployeeTypeId { get; set; }
    }
}
