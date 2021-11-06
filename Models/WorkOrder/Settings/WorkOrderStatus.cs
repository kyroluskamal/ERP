using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.WorkOrder.Settings
{
    public class WorkOrderStatus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, add a status")]
        [MaxLength(30)]
        public string Status { get; set; }
        public WorkOrders WorkOrders { get; set; }
        public int WorkOrdersId { get; set; }
    }
}
