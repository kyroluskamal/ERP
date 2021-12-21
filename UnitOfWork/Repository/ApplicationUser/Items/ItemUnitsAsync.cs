using ERP.Data;
using ERP.Models.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Items
{
    public class ItemUnitsAsync : OwnerRepositoryAsync<Units>, IItemUnitsAsync
    {
        public ItemUnitsAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(Units Unit)
        {
            ApplicationDbContext.Units.Update(Unit);
        }
    }
}
