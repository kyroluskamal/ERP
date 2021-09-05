using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Identity
{
    public class ApplicationUserRoleManager : RoleManager<ApplicationUserRole>
    {
        public ApplicationUserRoleManager(IRoleStore<ApplicationUserRole> store, 
            IEnumerable<IRoleValidator<ApplicationUserRole>> roleValidators, 
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
            ILogger<RoleManager<ApplicationUserRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
