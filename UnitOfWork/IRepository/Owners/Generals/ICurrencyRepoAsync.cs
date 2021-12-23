using ERP.Areas.Owners.Models;

namespace ERP.UnitOfWork.IRepository.Owners.Generals
{
    public interface ICurrencyRepoAsync : IRepositoryAsync<Currency>
    {
        void Update(Currency Currency);
    }
}
