﻿using System.ComponentModel.DataAnnotations;

namespace ERP.Areas.Owners.Models
{
    public class OwnerLogin
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
