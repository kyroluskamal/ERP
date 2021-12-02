using ERP.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Inventory
{
    public interface IInventoriesRepoAsync : IRepositoryAsync<Inventories>
    {
        void Update(Inventories Inventories);
    }
}
