using ERP.Models.Items;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Items
{
    public interface IItemNotesRepoAsync : IRepositoryAsync<ItemNotes>
    {
        void Update(ItemNotes itemNotes);
    }
}
