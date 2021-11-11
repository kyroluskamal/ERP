using ERP.Areas.Tenants.Data;
using ERP.Areas.Tenants.Models;
using ERP.UnitOfWork.IRepository.Tenants;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.Repository.Tenants
{
    public class TenantRepository : TenantsRepositoryAsync<TenantsInfo>, ITenantsRepositoryAsync
    {
        public TenantRepository(TenantsDbContext tenantsDbContext) : base(tenantsDbContext)
        {
            TenantsDbContext = tenantsDbContext;
        }

        public TenantsDbContext TenantsDbContext { get; }

        public async Task<bool> IsSubdomainExistAsync(string subdomain)
        {
            var tenant = await TenantsDbContext.Tenants.FirstOrDefaultAsync(x => x.Subdomain == subdomain);
            return tenant != null;
        }

        public void Update(TenantsInfo TenantsInfo)
        {
            TenantsDbContext.Update(TenantsInfo);
        }

        public async Task<TenantsInfo> TenantBySubdomainAsync(string subdomain)
        {
            return await TenantsDbContext.Tenants.FirstOrDefaultAsync(x => x.Subdomain == subdomain);
        }

        public async Task<TenantsInfo> TenantByUsernameAsync(string username)
        {
            return await TenantsDbContext.Tenants.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<TenantsInfo> TenantByEmailAsync(string Email)
        {
            return await TenantsDbContext.Tenants.FirstOrDefaultAsync(x => x.Email == Email);
        }
    }
}
