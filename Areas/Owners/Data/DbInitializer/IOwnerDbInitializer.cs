using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.Owners.Data.DbInitializer
{
    public interface IOwnerDbInitializer
    {
        void Initialize();
    }
}
