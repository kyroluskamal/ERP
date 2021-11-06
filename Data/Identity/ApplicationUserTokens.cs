using Microsoft.AspNetCore.Identity;

namespace ERP.Data.Identity
{
    public class ApplicationUserTokens : IdentityUserToken<int>
    {
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthToken { get; set; }
        public string IdToken { get; set; }
    }
}
