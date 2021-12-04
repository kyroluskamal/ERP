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
        [Required(ErrorMessage = "Required_field")]
        public string PostalCode { get; set; }

        public Inventories Inventory { get; set; }
        public int InventoryId { get; set; }
    }
}
