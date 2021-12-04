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
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Status { get; set; }
        public WorkOrders WorkOrders { get; set; }
        public int WorkOrdersId { get; set; }
    }
}
