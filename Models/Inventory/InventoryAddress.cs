using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Inventory
{
    public class InventoryAddress
    {
        public int Id { get; set; }
        public string BuildingNo { get; set; }
        public string FlatNo { get; set; }
        [Required(ErrorMessage = "You need to add any info for the address")]
        public string AddressLine_1 { get; set; }
        public string AddressLine_2 { get; set; }
        [Required(ErrorMessage = "Add the postal code")]
        public string PostalCode { get; set; }

        public Inventories Inventory { get; set; }
        public int InventoryId { get; set; }
    }
}
