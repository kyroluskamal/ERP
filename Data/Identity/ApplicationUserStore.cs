using ERP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ERP.Data.Identity
{
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationUserRole, ApplicationDbContext, int, IdentityUserClaim<int>,
        ApplicationUserUserRoles, IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>>
    {
        public ApplicationUserStore(ApplicationDbContext context,
            IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
