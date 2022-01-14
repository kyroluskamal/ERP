using ERP.Models.Items;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Items
{
    public interface IItemDescriptionRepoAsync : IRepositoryAsync<ItemDescription>
    {
        void Update(ItemDescription itemDescription);
    }
}
