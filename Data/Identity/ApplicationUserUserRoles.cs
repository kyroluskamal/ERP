using ERP.Models;
using Microsoft.AspNetCore.Identity;

namespace ERP.Data.Identity
{
    public class ApplicationUserUserRoles : IdentityUserRole<int>
    {
        public ApplicationUser AppUser { get; set; }
        public ApplicationUserRole Role { get; set; }
    }
}
