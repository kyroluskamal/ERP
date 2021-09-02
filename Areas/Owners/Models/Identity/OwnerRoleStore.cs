using ERP.Areas.Owners.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerRoleStore : RoleStore<OwnerRole, OwnersDbContext>
    {
        public OwnerRoleStore(OwnersDbContext OwnersDbContext, IdentityErrorDescriber describer = null) : base(OwnersDbContext, describer)
        {
        }
    }
}
