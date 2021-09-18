using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
