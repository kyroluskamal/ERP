using ERP.Data;
using ERP.Models.Inventory;
using ERP.UnitOfWork.IRepository.ApplicationUser.Inventory;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Inventory
{
    public class InventoriesRepoAsync : OwnerRepositoryAsync<Inventories>, IInventoriesRepoAsync
    {
        public InventoriesRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(Inventories Inventory)
        {
            ApplicationDbContext.Update(Inventory);
        }
    }
}
