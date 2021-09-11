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

        public TenantsInfo TenantBySubdomain(string subdomain)
        {
            return  TenantsDbContext.Tenants.FirstOrDefault(x => x.Subdomain == subdomain);

        }

        public TenantsInfo TenantByUsername(string username)
        {
            return TenantsDbContext.Tenants.FirstOrDefault(x => x.Username == username);
        }

        public TenantsInfo TenantByEmail(string Email)
        {
            return TenantsDbContext.Tenants.FirstOrDefault(x => x.Email == Email);
        }
    }
}
