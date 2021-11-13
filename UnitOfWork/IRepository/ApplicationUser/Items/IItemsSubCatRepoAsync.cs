using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Items
{
    public interface IItemsSubCatRepoAsync : IRepositoryAsync<ItemSubCategory>
    {
        void Update(ItemSubCategory ItemSubCategory);
        Task<List<ItemSubCategory>> GetSubCats_By_MainCat_Id_Async(int MainCat_id);
    }
}
