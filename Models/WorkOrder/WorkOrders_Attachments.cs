using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.WorkOrder
{
    public class WorkOrders_Attachments
    {
        public int Id { get; set; }
        [Required]
        public byte[] Attachments { get; set; }

        public WorkOrders WorkOrders { get; set; }
        public int WorkOrdersId { get; set; }
    }
}
