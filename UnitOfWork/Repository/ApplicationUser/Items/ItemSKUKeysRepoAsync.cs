using ERP.Data;
using ERP.Models.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Items
{
    public class ItemSKUKeysRepoAsync : ApplicationUserRepositoryAsync<ItemSKUKeys>, IItemSKUKeysRepoAsync
    {
        public ItemSKUKeysRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(ItemSKUKeys ItemSKUKeys)
        {
            ApplicationDbContext.ItemSKUKeys.Update(ItemSKUKeys);
        }
    }
}
