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
    public class ItemsSubCatRepoAsync : OwnerRepositoryAsync<ItemSubCategory>, IItemsSubCatRepoAsync
    {
        public ItemsSubCatRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public async Task<IEnumerable<ItemSubCategory>> GetSubCats_By_MainCat_Id_Async(int MainCat_id)
        {
            var SubCats = await ApplicationDbContext.ItemSubCategories.ToListAsync();
            return SubCats.Where(x => x.ItemMainCategoryId == MainCat_id);
        }

        public void Update(ItemSubCategory itemSubCategory)
        {
            ApplicationDbContext.Update(itemSubCategory);
        }
    }
}
