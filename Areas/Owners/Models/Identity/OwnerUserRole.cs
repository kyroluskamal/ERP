using Microsoft.AspNetCore.Identity;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerUserRole : IdentityUserRole<int>
    {
        public Owner Owner { get; set; }
        public OwnerRole Role { get; set; }
    }
}
