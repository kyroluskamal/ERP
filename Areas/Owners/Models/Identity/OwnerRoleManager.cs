using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerRoleManager : RoleManager<OwnerRole>
    {
        public OwnerRoleManager(IRoleStore<OwnerRole> store, IEnumerable<IRoleValidator<OwnerRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<OwnerRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
