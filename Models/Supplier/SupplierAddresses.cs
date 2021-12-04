using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Supplier
{
    public class SupplierAddresses
    {
        public int Id { get; set; }
        public string BuildingNo { get; set; }
        public string FlatNo { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string AddressLine_1 { get; set; }
        public string AddressLine_2 { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string PostalCode { get; set; }
        public Suppliers Suppliers { get; set; }
        public int SuppliersId { get; set; }
    }
}
