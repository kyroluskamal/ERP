using ERP.Areas.Tenants.Data;
using ERP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public class TenantsUnitOfWork : IUnitOfWork
    {
        public TenantsDbContext TenantsDbContext { get; }

        public TenantsUnitOfWork(TenantsDbContext tenantsDbContext)
        {
            TenantsDbContext = tenantsDbContext;
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
