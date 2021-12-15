using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Inventory
{
    public class InventoryAddress
    {
        public int Id { get; set; }
        public string BuildingNo { get; set; }
        public string FlatNo { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string AddressLine_1 { get; set; }
        public string AddressLine_2 { get; set; }
        public string PostalCode { get; set; }
    }
}
