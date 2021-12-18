using ERP.Data;
using ERP.Models.Generals;
using ERP.UnitOfWork.IRepository.ApplicationUser.Generals;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Countries
{
    public class CountryRepoAsync : ApplicationUserRepositoryAsync<Country>, ICountryRepoAsync
    {
        public CountryRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(Country Country)
        {
            ApplicationDbContext.Update(Country);
        }
    }
}
