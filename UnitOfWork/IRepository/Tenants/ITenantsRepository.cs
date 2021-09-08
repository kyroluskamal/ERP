using ERP.Areas.Tenants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork.IRepository.Tenants
{
    public interface ITenantsRepository : IRepository<TenantsInfo>
    {
        void Update(TenantsInfo TenantsInfo);
        bool IsSubdomainExist(string subdomain);
    }
}
