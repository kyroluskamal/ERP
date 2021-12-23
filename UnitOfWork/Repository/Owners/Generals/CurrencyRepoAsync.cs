using ERP.Areas.Owners.Data;
using ERP.Areas.Owners.Models;
using ERP.UnitOfWork.IRepository.Owners.Generals;

namespace ERP.UnitOfWork.Repository.Owners.Generals
{
    public class CurrencyRepoAsync : OwnersRepositoryAsync<Currency>, ICurrencyRepoAsync
    {
        public CurrencyRepoAsync(OwnersDbContext ownersDbContext) : base(ownersDbContext)
        {
            OwnersDbContext = ownersDbContext;
        }

        public OwnersDbContext OwnersDbContext { get; }

        public void Update(Currency Currency)
        {
            OwnersDbContext.Update(Currency);
        }
    }
}
