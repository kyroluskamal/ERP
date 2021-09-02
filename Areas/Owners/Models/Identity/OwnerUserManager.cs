using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerUserManager : UserManager<Owner>
    {
        public OwnerUserManager(IUserStore<Owner> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Owner> passwordHasher,
            IEnumerable<IUserValidator<Owner>> userValidators,
            IEnumerable<IPasswordValidator<Owner>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
            IServiceProvider services, ILogger<UserManager<Owner>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}
