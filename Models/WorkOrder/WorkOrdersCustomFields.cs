using ERP.Models.CutomFields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.WorkOrder
{
    public class WorkOrdersCustomFields
    {
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }

        public WorkOrders WorkOrders { get; set; }
        public int WorkOrdersId { get; set; }
        public Fields_Per_Service Fields_Per_Service { get; set; }
        public int Fields_Per_ServiceId { get; set; }
    }
}
