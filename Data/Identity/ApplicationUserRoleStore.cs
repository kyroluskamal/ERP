using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
