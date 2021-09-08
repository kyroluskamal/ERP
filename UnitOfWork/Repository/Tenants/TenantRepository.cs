using ERP.Areas.Tenants.Data;
using ERP.Areas.Tenants.Models;
using ERP.UnitOfWork.IRepository.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.Repository.Tenants
{
    public class TenantRepository : TenantsRepository<TenantsInfo>, ITenantsRepository
    {
        public TenantRepository(TenantsDbContext tenantsDbContext) : base(tenantsDbContext)
        {
            TenantsDbContext = tenantsDbContext;
        }

        public TenantsDbContext TenantsDbContext { get; }

        public bool IsSubdomainExist(string subdomain)
        {
            var tenant = TenantsDbContext.Tenants.FirstOrDefault(x => x.Subdomain == subdomain);
            return tenant != null;
        }

        public void Update(TenantsInfo TenantsInfo)
        {
            TenantsDbContext.Update(TenantsInfo);
        }

     

        
    }
}
