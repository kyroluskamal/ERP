using ERP.UnitOfWork.IRepository.Owners;
using System;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_Owners : IDisposable
    {
        IOwnersRepository Owners { get; }
        Task<int> Save();
    }
}
