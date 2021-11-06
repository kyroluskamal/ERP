using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.WorkOrder
{
    public class WorkOrders_Description
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a description")]
        public string Description { get; set; }

        public WorkOrders WorkOrders { get; set; }
        public int WorkOrdersId { get; set; }
    }
}
