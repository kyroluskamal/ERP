using ERP.Areas.Owners.Data;
using ERP.UnitOfWork.IRepository.Owners;
using ERP.UnitOfWork.IRepository.Owners.Generals;
using ERP.UnitOfWork.Repository.Owners;
using ERP.UnitOfWork.Repository.Owners.Generals;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public class OwnerUnitOfWork : IUnitOfWork_Owners
    {
        private OwnersDbContext OwnersDbContext { get; }
        public IOwnersRepository Owners { get; private set; }

        public ICountryRepoAsync Countries { get; private set; }

        public ICurrencyRepoAsync Currencies { get; private set; }

        public OwnerUnitOfWork(OwnersDbContext ownersDbContext)
        {
            OwnersDbContext = ownersDbContext;
            Owners = new OwnerRepository(ownersDbContext);
            Countries = new CountryRepoAsync(ownersDbContext);
            Currencies = new CurrencyRepoAsync(ownersDbContext);
        }


        public async void Dispose()
        {
            await OwnersDbContext.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await OwnersDbContext.SaveChangesAsync();
        }
    }
}
