using ERP.Models.Supplier;
namespace ERP.UnitOfWork.IRepository.ApplicationUser.SuppliersRepo
{
    public interface ISuppliersRepoAsync : IRepositoryAsync<Suppliers>
    {
        void Update(Suppliers supplier);
    }
}
