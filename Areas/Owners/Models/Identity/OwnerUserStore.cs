using ERP.Areas.Owners.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerUserStore : UserStore<Owner, OwnerRole, OwnersDbContext, int, IdentityUserClaim<int>,
        OwnerUserRole, IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>>
    {
        public OwnerUserStore(OwnersDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
