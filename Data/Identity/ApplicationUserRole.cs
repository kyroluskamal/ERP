using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ERP.Data.Identity
{
    public class ApplicationUserRole : IdentityRole<int>
    {
        public ApplicationUserRole()
        {
        }

        public ApplicationUserRole(string roleName) : base(roleName)
        {
        }
        public ICollection<ApplicationUserUserRoles> UserRole { get; set; }

    }
}
