using ERP.Areas.Owners.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Areas.Owners.Models
{
    public class Owner : IdentityUser<int>
    {
        [Required(ErrorMessage = "You first name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You last name is required")]
        public string LastName { get; set; }
        public ICollection<OwnerUserRole> UserRole { get; set; }

    }
}
