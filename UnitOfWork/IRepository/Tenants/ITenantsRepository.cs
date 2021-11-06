using ERP.Areas.Tenants.Models;

namespace ERP.UnitOfWork.IRepository.Tenants
{
    public interface ITenantsRepository : IRepository<TenantsInfo>
    {
        void Update(TenantsInfo TenantsInfo);
        bool IsSubdomainExist(string subdomain);
        TenantsInfo TenantBySubdomain(string subdomain);
        TenantsInfo TenantByUsername(string username);
        TenantsInfo TenantByEmail(string Email);
    }
}
