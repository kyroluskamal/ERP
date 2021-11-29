using ERP.Models.COCs;

namespace ERP.Models.WorkOrder
{
    public class WorkOrdersClients
    {
        public int Id { get; set; }
        public WorkOrders WorkOrders { get; set; }
        public int WorkOrdersId { get; set; }

        public COC COCs { get; set; }
        public int COCid { get; set; }
    }
}
