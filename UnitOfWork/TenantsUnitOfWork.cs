using ERP.Areas.Tenants.Data;
using ERP.UnitOfWork.IRepository.Tenants;
using ERP.UnitOfWork.Repository.Tenants;

namespace ERP.UnitOfWork
{
    public class TenantsUnitOfWork : IUnitOfWork_Tenants
    {
        public TenantsDbContext TenantsDbContext { get; }

        public ITenantsRepository Tenants { get; private set; }

        public TenantsUnitOfWork(TenantsDbContext tenantsDbContext)
        {
            TenantsDbContext = tenantsDbContext;
            Tenants = new TenantRepository(TenantsDbContext);
        }


        public async void Dispose()
        {
            await TenantsDbContext.DisposeAsync();
        }

        public async void Save()
        {
            await TenantsDbContext.SaveChangesAsync();
        }

    }
}
