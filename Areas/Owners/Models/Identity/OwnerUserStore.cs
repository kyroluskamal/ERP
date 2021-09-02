using ERP.Areas.Owners.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ERP.Areas.Owners.Models.Identity
{
    public class OwnerUserStore : UserStore<Owner>
    {
        public OwnersDbContext OnerDbcontext { get; set; }
        public OwnerUserStore(OwnersDbContext OwnerDbcontext, IdentityErrorDescriber describer = null) : base(OwnerDbcontext, describer)
        {
        }
    }
}
