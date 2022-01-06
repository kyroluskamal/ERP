using ERP.Data;
using ERP.Models.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Items
{
    public class ItemRepoASync : ApplicationUserRepositoryAsync<Item>, IItemsRepoAsync
    {
        public ItemRepoASync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(Item Item)
        {
            ApplicationDbContext.Items.Update(Item);
        }
    }
}
