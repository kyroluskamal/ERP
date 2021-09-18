using ERP.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Identity
{
    public class ApplicationUserUserRoles : IdentityUserRole<int>
    {
        public ApplicationUser AppUser { get; set; }
        public ApplicationUserRole Role { get; set; }
    }
}
