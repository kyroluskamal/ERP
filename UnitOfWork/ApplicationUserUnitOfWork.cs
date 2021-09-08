using ERP.Areas.Tenants.Data;
using ERP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public class ApplicationUserUnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext ApplicationDbContext { get; }

        public ApplicationUserUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }


        public async void Dispose()
        {
            await ApplicationDbContext.DisposeAsync();
        }

        public async void Save()
        {
            await ApplicationDbContext.SaveChangesAsync();
        }
    }
}
