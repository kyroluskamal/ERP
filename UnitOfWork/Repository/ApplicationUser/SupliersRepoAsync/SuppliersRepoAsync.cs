using ERP.Data;
using ERP.Models.Supplier;
using ERP.UnitOfWork.IRepository.ApplicationUser.SuppliersRepo;

namespace ERP.UnitOfWork.Repository.ApplicationUser.SupliersRepoAsync
{
    public class SuppliersRepoAsync : OwnerRepositoryAsync<Suppliers>, ISuppliersRepoAsync
    {
        public SuppliersRepoAsync(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public void Update(Suppliers supplier)
        {
            ApplicationDbContext.Suppliers.Update(supplier);
        }
    }
}
