using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.WorkOrder.Settings
{
    public class WorkOrdersActions
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, add an action name")]
        [MaxLength(30)]
        public string ActionName { get; set; }
        public WorkOrders WorkOrders { get; set; }
        public int WorkOrdersId { get; set; }
    }
}
