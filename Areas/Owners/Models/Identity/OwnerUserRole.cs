using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerUserRole : IdentityUserRole<int>
    {
        public Owner Owner { get; set; }
        public OwnerRole Role { get; set; }
    }
}
