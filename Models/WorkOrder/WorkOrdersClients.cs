using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.WorkOrder
{
    public class WorkOrdersClients
    {
        public int Id { get; set; }
        public WorkOrders WorkOrders { get; set; }
        public int WorkOrdersId { get; set; }

        public ERP.Models.COC.COC COCs { get; set; }
        public int COCid { get; set; }
    }
}
