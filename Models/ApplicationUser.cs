using ERP.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required(ErrorMessage = "Your first name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Your last name is required")]
        public string LastName { get; set; }
        [Required]
        public bool IsClientOrStaff { get; set; }
        public ICollection<ApplicationUserUserRoles> UserRole { get; set; }

    }
}
