using ERP.Areas.Owners.Data;
using ERP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public class OwnerUnitOfWork : IUnitOfWork
    {
        public OwnersDbContext OwnersDbContext { get; }

        public OwnerUnitOfWork(OwnersDbContext ownersDbContext)
        {
            OwnersDbContext = ownersDbContext;
        }


        public async void Dispose()
        {
            await OwnersDbContext.DisposeAsync();
        }

        public async void Save()
        {
            await OwnersDbContext.SaveChangesAsync();
        }
    }
}
