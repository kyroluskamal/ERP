using ERP.Areas.Owners.Data;
using ERP.Areas.Owners.Models;
using ERP.UnitOfWork.IRepository.Owners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.Repository.Owners
{
    public class OwnerRepository : OwnersRepository<Owner>, IOwnersRepository
    {
        public OwnerRepository(OwnersDbContext ownersDbContext) : base(ownersDbContext)
        {
            OwnersDbContext = ownersDbContext;
        }
        public OwnersDbContext OwnersDbContext { get; }
        public Owner OwnerByEmail(string Email)
        {
            return OwnersDbContext.Users.SingleOrDefault(x=>x.Email == Email);
        }

        public Owner OwnerByUsername(string username)
        {
            return OwnersDbContext.Users.SingleOrDefault(x => x.UserName == username);
        }

        public void Update(Owner Owner)
        {
            OwnersDbContext.Update(Owner);
        }
    }
}
