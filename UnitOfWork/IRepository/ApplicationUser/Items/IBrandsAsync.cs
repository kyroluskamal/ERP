using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.IRepository.ApplicationUser.Items
{
    public interface IBrandsAsync : IRepositoryAsync<Brands>
    {
        void Update(Brands Brands);
    }
}
