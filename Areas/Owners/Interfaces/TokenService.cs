using ERP.Areas.Owners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.Owners.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Owner owner);
    }
}
