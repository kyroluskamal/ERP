using ERP.Data;
using ERP.Models.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.Repository.ApplicationUser.Items
{
    public class BrandsRepoAsync : OwnerRepositoryAsync<Brands>, IBrandsAsync
    {
        public BrandsRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(Brands Brands)
        {
            ApplicationDbContext.Brands.Update(Brands);
        }
    }
}
