using ERP.Areas.Owners.Data;
using ERP.Data;
using ERP.UnitOfWork.IRepository.Owners;
using ERP.UnitOfWork.Repository.Owners;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public class OwnerUnitOfWork : IUnitOfWork_Owners
    {
        public OwnersDbContext OwnersDbContext { get; }
        public IOwnersRepository Owners { get; private set; }


        public OwnerUnitOfWork(OwnersDbContext ownersDbContext)
        {
            OwnersDbContext = ownersDbContext;
            Owners = new OwnerRepository(ownersDbContext);
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
