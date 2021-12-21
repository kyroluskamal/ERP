using ERP.UnitOfWork.IRepository.Owners;
using ERP.UnitOfWork.IRepository.Owners.Generals;
using System;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_Owners : IDisposable
    {
        IOwnersRepository Owners { get; }
        ICountryRepoAsync Countries { get; }

        Task<int> SaveAsync();
    }
}
