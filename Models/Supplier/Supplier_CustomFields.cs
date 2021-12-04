using ERP.Models.CutomFields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Supplier
{
    public class Supplier_CustomFields
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Value { get; set; }

        public Suppliers Suppliers { get; set; }
        public int SuppliersId { get; set; }
        public Fields_Per_Service Fields_Per_Service { get; set; }
        public int Fields_Per_ServiceId { get; set; }
    }
}
