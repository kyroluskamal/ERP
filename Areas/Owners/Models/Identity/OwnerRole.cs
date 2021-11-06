using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerRole : IdentityRole<int>
    {
        public OwnerRole()
        {
        }

        public OwnerRole(string roleName) : base(roleName)
        {
        }
        public ICollection<OwnerUserRole> UserRole { get; set; }
    }
}
