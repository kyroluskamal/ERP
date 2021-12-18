using ERP.Models.Generals;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Generals
{
    public interface ICountryRepoAsync : IRepositoryAsync<Country>
    {
        void Update(Country Country);
    }
}
