using ERP.UnitOfWork.IRepository.ApplicationUser.Items;
using System;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_ApplicationUser : IDisposable
    {
        IItemMainCatRepoAsync ItemMainCategory { get; }
        Task SetConnectionStringAsync(string ConnectionString);
        Task<int> SaveAsync();
        void Save();
    }
}
