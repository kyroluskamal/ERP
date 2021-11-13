using ERP.Data;
using ERP.Models.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Items
{
    public class ItemsSubCatRepoAsync : ApplicationUserRepositoryAsync<ItemSubCategory>, IItemsSubCatRepoAsync
    {
        public ItemsSubCatRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public async Task<List<ItemSubCategory>> GetSubCats_By_MainCat_Id_Async(int MainCat_id)
        {
            return await ApplicationDbContext.ItemSubCategories.Where(x => x.ItemMainCategoryId == MainCat_id).ToListAsync();
        }

        public void Update(ItemSubCategory itemSubCategory)
        {
            ApplicationDbContext.Update(itemSubCategory);
        }
    }
}
