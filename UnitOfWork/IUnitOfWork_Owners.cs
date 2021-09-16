using ERP.UnitOfWork.IRepository.Owners;
using ERP.UnitOfWork.IRepository.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_Owners : IDisposable
    {
        IOwnersRepository Owners { get; }
        void Save();
    }
}
