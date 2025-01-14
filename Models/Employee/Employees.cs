﻿using ERP.Models.Attendance.AttendenceSettings;
using ERP.Models.Branches;
using ERP.Models.Generals;
using ERP.Models.OrganizationalStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Employee
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public string MiddleName { get; set; }

        [EmailAddress(ErrorMessage = "IncorrecEmail")]
        public string PersonalEmail { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "tinyint")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime JoinDate { get; set; }

        public byte[] ProfileIMage { get; set; }
        [Column(TypeName = "bit")]
        public bool HasCustomFields { get; set; }

        public ICollection<EmployeePaperImages> PaperImages { get; set; }
        public ICollection<EmployeeAddress> EmpAddress { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }
        public int UserId { get; set; }

        public string CountryName { get; set; }
        public string CountryNameCode { get; set; }
        public int CountryId { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public Designation Designation { get; set; }
        public int? DesignationId { get; set; }
        public EmployeeLevel EmployeeLevel { get; set; }
        public int? EmployeeLevelId { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int? EmployeeTypeId { get; set; }

        public HolidayLists HolidayLists { get; set; }
        public int HolidayListsId { get; set; }

        public VacationsPolicy_LeavePolicy VacationsPolicy_LeavePolicy { get; set; }
        public int VacationsPolicy_LeavePolicyId { get; set; }

        public ICollection<Employees_In_Branch> Employees_In_Branch { get; set; }
    }
}
