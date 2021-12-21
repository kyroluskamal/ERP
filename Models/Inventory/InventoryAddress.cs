using ERP.Models.Generals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Inventory
{
    public class InventoryAddress
    {
        public int Id { get; set; }
        [MaxLength(15, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string BuildingNo { get; set; }
        [MaxLength(15, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string FlatNo { get; set; }
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string StreetName { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string AddressLine_1 { get; set; }
        public string AddressLine_2 { get; set; }
        [MaxLength(15, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string PostalCode { get; set; }
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string City { get; set; }
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Government { get; set; }
        public string CountryName { get; set; }
        public string CountryNameCode { get; set; }
        public int CountryId { get; set; }
        [ForeignKey(nameof(InventoriesId))]
        public virtual Inventories Inventories { get; set; }
        public int InventoriesId { get; set; }
        [NotMapped]
        public string Subdomain { get; set; }

    }
}
