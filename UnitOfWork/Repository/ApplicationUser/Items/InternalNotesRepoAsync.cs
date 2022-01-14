using ERP.Data;
using ERP.Models.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Items
{
    public class InternalNotesRepoAsync : ApplicationUserRepositoryAsync<InternalNotes>, IInternalNotesRepoAsync
    {
        public InternalNotesRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(InternalNotes internalNotes)
        {
            ApplicationDbContext.InternalNotes.Update(internalNotes);
        }
    }
}
