using ERP.Data;
using ERP.Models.Inventory;
using ERP.UnitOfWork.IRepository.ApplicationUser.Inventory;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Inventory
{
    public class InventoryAddressRepoAsync : ApplicationUserRepositoryAsync<InventoryAddress>, IInventoryAddressRepoAsync
    {
        private readonly ApplicationDbContext applicationDbContext;

        public InventoryAddressRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Update(InventoryAddress address)
        {
            applicationDbContext.InventoryAddresses.Update(address);
        }
    }
}
