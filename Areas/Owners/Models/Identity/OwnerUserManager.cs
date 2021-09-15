using ERP.Areas.Owners.CustomTokenProviders.EmailConfirmation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerUserManager : UserManager<Owner>
    {
        public OwnerUserManager(IUserStore<Owner> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Owner> passwordHasher, IEnumerable<IUserValidator<Owner>> userValidators,
            IEnumerable<IPasswordValidator<Owner>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, 
            ILogger<UserManager<Owner>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            RegisterTokenProvider(TokenOptions.DefaultProvider, new EmailTokenProvider<Owner>());
            //RegisterTokenProvider(TokenOptions.DefaultProvider, new EmailTokenProvider<Owner>());
        }
        //public virtual Task<string> CustomEmailConfirmationTokenAsync(Owner user)
        //{
        //    ThrowIfDisposed();
        //    return GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, ConfirmEmailTokenPurpose);
        //}

        //public override Task<string> GenerateEmailConfirmationTokenAsync(Owner user)
        //{
        //    ThrowIfDisposed();
        //    return GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, ConfirmEmailTokenPurpose + user.Email);
        //}
        //public override Task<IdentityResult> ConfirmEmailAsync(Owner user, string token)
        //{
        //    return ValidateAsync();
        //}
    }
}
