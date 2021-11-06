using ERP.UnitOfWork.IRepository.Owners;
using System;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_Owners : IDisposable
    {
        IOwnersRepository Owners { get; }
        void Save();
    }
}
