﻿using ERP.Models.Employee;
using ERP.Models.Generals;
using ERP.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Supplier
{
    public class Suppliers
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(50, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string BusinessName { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [PhoneNumber(ErrorMessage = "NOT_VALID_PHONE_NUMBER")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.PhoneNumber)]
        [PhoneNumber(ErrorMessage = "NOT_VALID_PHONE_NUMBER")]
        public string MobilePhone { get; set; }
        public string TaxID { get; set; }
        public string CR { get; set; }
        [EmailAddress(ErrorMessage = "IncorrecEmail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal OpeningBalance { get; set; }
        public string Notes { get; set; }
        public string Currency { get; set; }
        public int CurrencyId { get; set; }
        public string CountryName { get; set; }
        public string CountryNameCode { get; set; }
        public int CountryId { get; set; }
        [ForeignKey(nameof(AddedBy_UserId))]
        public ApplicationUser ApplicationUser { get; set; }
        public int? AddedBy_UserId { get; set; } //Not Required temporary
        public string AddedBy_UserName { get; set; }
        [NotMapped]
        public string Subdomain { get; set; }
    }
}
