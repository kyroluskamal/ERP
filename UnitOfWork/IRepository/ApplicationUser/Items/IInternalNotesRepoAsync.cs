using ERP.Models.Items;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Items
{
    public interface IInternalNotesRepoAsync : IRepositoryAsync<InternalNotes>
    {
        void Update(InternalNotes internalNotes);
    }
}
