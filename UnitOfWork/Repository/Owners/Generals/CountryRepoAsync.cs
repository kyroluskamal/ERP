using ERP.Areas.Owners.Data;
using ERP.Areas.Owners.Models;
using ERP.Data;
using ERP.Models.Generals;
using ERP.UnitOfWork.IRepository.Owners.Generals;

namespace ERP.UnitOfWork.Repository.Owners.Generals
{
    public class CountryRepoAsync : OwnersRepositoryAsync<Country>, ICountryRepoAsync
    {
        public CountryRepoAsync(OwnersDbContext ownersDbContext) : base(ownersDbContext)
        {
            OwnersDbContext = ownersDbContext;
        }

        public OwnersDbContext OwnersDbContext { get; }

        public void Update(Country Country)
        {
            OwnersDbContext.Update(Country);
        }
    }
}
