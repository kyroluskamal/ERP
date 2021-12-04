using ERP.UnitOfWork.IRepository.ApplicationUser.Inventory;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;
using System;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_ApplicationUser : IDisposable
    {
        IItemsMainCatRepoAsync ItemMainCategory { get; }
        IInventoriesRepoAsync Inventories { get; }
        IItemsSubCatRepoAsync Item_SubCats { get; }
        IItemUnitsAsync ItemUnits { get; }
        IBrandsAsync ItemBrands { get; }

        Task SetConnectionStringAsync(string ConnectionString);
        Task<int> SaveAsync();
        int Save();
    }
}
