using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerSignInManager : SignInManager<Owner>
    {
        public OwnerSignInManager(UserManager<Owner> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<Owner> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<Owner>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<Owner> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }
    }
}
