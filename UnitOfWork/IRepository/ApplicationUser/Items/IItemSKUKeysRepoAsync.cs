using ERP.Models.Items;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Items
{
    public interface IItemSKUKeysRepoAsync : IRepositoryAsync<ItemSKUKeys>
    {
        void Update(ItemSKUKeys ItemSKUKeys);
    }
}
