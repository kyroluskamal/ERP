using ERP.UnitOfWork.IRepository.ApplicationUser.Inventory;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.SuppliersRepo;
using System;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public interface IUnitOfWork_ApplicationUser : IDisposable
    {
        IItemsMainCatRepoAsync ItemMainCategory { get; }
        ISuppliersRepoAsync Suppliers { get; }
        IInventoriesRepoAsync Inventories { get; }
        IInventoryAddressRepoAsync InventoryAddress { get; }
        IItemsSubCatRepoAsync Item_SubCats { get; }
        IItemUnitsAsync ItemUnits { get; }
        IBrandsAsync ItemBrands { get; }
        IItemsRepoAsync Items { get; }
        IItemSKUKeysRepoAsync ItemSKUKeys { get; }

        Task SetConnectionStringAsync(string ConnectionString);
        Task<int> SaveAsync();
        int Save();
    }
}
