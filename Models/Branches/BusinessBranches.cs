﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Branches
{
    public class BusinessBranches
    {
        public int Id { get; set; }
        [Required]
        public string CurrentNumber { get; set; }
        [Required(ErrorMessage = "Please, write a name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }
        public string Terlephone { get; set; }
        public int WorkingHours { get; set; }
        public string Description{ get; set; }
        public string Location { get; set; }
        public ICollection<Employees_In_Branch> Employees_In_Branch { get; set; }
    }
}