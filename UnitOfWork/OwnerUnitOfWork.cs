using ERP.Areas.Owners.Data;
using ERP.UnitOfWork.IRepository.Owners;
using ERP.UnitOfWork.Repository.Owners;

namespace ERP.UnitOfWork
{
    public class OwnerUnitOfWork : IUnitOfWork_Owners
    {
        private OwnersDbContext OwnersDbContext { get; }
        public IOwnersRepository Owners { get; private set; }


        public OwnerUnitOfWork(OwnersDbContext ownersDbContext)
        {
            OwnersDbContext = ownersDbContext;
            Owners = new OwnerRepository(OwnersDbContext);
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
