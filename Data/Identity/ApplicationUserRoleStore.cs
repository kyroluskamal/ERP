using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Identity
{
    public class ApplicationUserRoleStore : RoleStore<ApplicationUserRole, ApplicationDbContext, int, ApplicationUserUserRoles, IdentityRoleClaim<int>>
    {
        public ApplicationUserRoleStore(ApplicationDbContext context, 
            IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
