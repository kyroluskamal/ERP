using ERP.Models.Inventory;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Inventory
{
    public interface IInventoryAddressRepoAsync : IRepositoryAsync<InventoryAddress>
    {
        void Update(InventoryAddress address);
    }
}
