using ERP.Data;
using ERP.Models.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Items
{
    public class ItemNotesRepoAsync : ApplicationUserRepositoryAsync<ItemNotes>, IItemNotesRepoAsync
    {
        public ItemNotesRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(ItemNotes itemNotes)
        {
            ApplicationDbContext.ItemNotes.Update(itemNotes);
        }
    }
}
