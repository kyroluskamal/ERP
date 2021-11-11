using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Items
{
    public interface IItemMainCatRepoAsync : IRepositoryAsync<ItemMainCategory>
    {
        void Update(ItemMainCategory ItemMainCategory);
    }
}
