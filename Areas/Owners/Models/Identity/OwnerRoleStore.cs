using ERP.Areas.Owners.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerRoleStore : RoleStore<OwnerRole, OwnersDbContext, int, OwnerUserRole, IdentityRoleClaim<int>>
    {
        public OwnerRoleStore(OwnersDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
