using ERP.Models.Employee;
using ERP.Utilities.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Inventory
{
    public class Inventories
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string WarehouseName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [PhoneNumber(ErrorMessage = "NOT_VALID_PHONE_NUMBER")]
        public string MobilePhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [PhoneNumber(ErrorMessage = "NOT_VALID_PHONE_NUMBER")]
        public string Telephone { get; set; }
        public string Notes { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool IsMainInventory { get; set; }

        [ForeignKey(nameof(AddedBy_UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int? AddedBy_UserId { get; set; } //Not Required temporary
        public string AddedBy_UserName { get; set; }

        public virtual InventoryAddress InventoryAddress { get; set; }

        [NotMapped]
        public string Subdomain { get; set; }
    }
}
