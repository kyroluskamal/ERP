using System;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_ApplicationUser : IDisposable
    {
        void SetConnectionString(string ConnectionString);
        void Save();
    }
}
