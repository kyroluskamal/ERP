using ERP.UnitOfWork.IRepository.Tenants;
using System;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_Tenants : IDisposable
    {
        ITenantsRepository Tenants { get; }
        void Save();
    }
}
