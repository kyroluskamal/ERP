using ERP.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [Column(TypeName ="tinyint")]
        public int IsClientOrStaffOrBoth { get; set; }
        public ICollection<ApplicationUserUserRoles> UserRole { get; set; }
    }
}
