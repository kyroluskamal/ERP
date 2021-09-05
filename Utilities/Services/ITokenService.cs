using ERP.Areas.Owners.Models;
using ERP.Models;

namespace ERP.Utilities.Services
{
    public interface ITokenService
    {
        string CreateOwnerToken(Owner owner);
        string CreateClientToken(ApplicationUser applicationUser);
    }
}
