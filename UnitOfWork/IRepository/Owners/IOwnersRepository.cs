using ERP.Areas.Owners.Models;

namespace ERP.UnitOfWork.IRepository.Owners
{
    public interface IOwnersRepository : IRepository<Owner>
    {
        void Update(Owner Owner);
        Owner OwnerByUsername(string username);
        Owner OwnerByEmail(string Email);
    }
}
