using ERP.Areas.Tenants.Models;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.IRepository.Tenants
{
    public interface ITenantsRepositoryAsync : IRepositoryAsync<TenantsInfo>
    {
        void Update(TenantsInfo TenantsInfo);
        Task<bool> IsSubdomainExistAsync(string subdomain);
        Task<TenantsInfo> TenantBySubdomainAsync(string subdomain);
        Task<TenantsInfo> TenantByUsernameAsync(string username);
        Task<TenantsInfo> TenantByEmailAsync(string Email);
    }
}
