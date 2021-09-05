using ERP.Areas.Tenants.Data;
using ERP.Areas.Tenants.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.Tenants.Services
{
    public class TenantProvider
    {
        public IHttpContextAccessor HttpAccessor;
        public TenantsDbContext DbContext { get; set; }
        public TenantProvider(TenantsDbContext dbContext, IHttpContextAccessor httpAccessor)
        {
            DbContext = dbContext;
            HttpAccessor = httpAccessor;
        }

        public string GetTenantConnectionString()
        {
            var subdomain = HttpAccessor.HttpContext.Request.Host.Host.Split(".kikoerp.com").First();
            if (subdomain == "kherp.com" || subdomain == "localhost") return "";
            var tenant = DbContext.Tenants.FirstOrDefault(x => x.Subdomain == subdomain);
            return  tenant==null? "":tenant.ConnectionString;
        }
    }
}
