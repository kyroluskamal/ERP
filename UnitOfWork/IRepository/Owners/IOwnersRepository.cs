using ERP.Areas.Owners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.IRepository.Owners
{
    public interface IOwnersRepository : IRepository<Owner>
    {
        void Update(Owner Owner);
        Owner OwnerByUsername(string username);
        Owner OwnerByEmail(string Email);
    }
}
