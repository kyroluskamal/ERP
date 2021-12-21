using ERP.Areas.Owners.Models;
using ERP.Models.Generals;

namespace ERP.UnitOfWork.IRepository.Owners.Generals
{
    public interface ICountryRepoAsync : IRepositoryAsync<Country>
    {
        void Update(Country Country);
    }
}
