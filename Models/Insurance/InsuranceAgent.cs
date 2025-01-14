﻿using ERP.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Insurance
{
    public class InsuranceAgent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(60, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }
        [EmailAddress(ErrorMessage = "IncorrecEmail")]
        public string Email { get; set; }
        public string Website { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }

        [ForeignKey(nameof(AddedBy_EmployeesId))]
        public Employees Employees { get; set; }
        public int? AddedBy_EmployeesId { get; set; }
    }
}
