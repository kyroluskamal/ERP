using ERP.Models.Items;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Items
{
    public interface IItemsRepoAsync : IRepositoryAsync<Item>
    {
        void Update(Item Item);
    }
}
