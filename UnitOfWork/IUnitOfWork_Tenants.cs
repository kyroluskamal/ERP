using ERP.UnitOfWork.IRepository.Tenants;
using System;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_Tenants : IDisposable
    {
        ITenantsRepositoryAsync Tenants { get; }
        Task<int> SaveAsync();
    }
}
