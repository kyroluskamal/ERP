using ERP.Data;
using ERP.Models.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Items
{
    public class ItemsMainCatRepoAsync : ApplicationUserRepositoryAsync<ItemMainCategory>, IItemsMainCatRepoAsync
    {
        public ItemsMainCatRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(ItemMainCategory ItemMainCategory)
        {
            ApplicationDbContext.Update(ItemMainCategory);
        }
    }
}
