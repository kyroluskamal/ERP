using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Items
{
    public interface IItemUnitsAsync : IRepositoryAsync<Units>
    {
        void Update(Units Unit);
    }
}
