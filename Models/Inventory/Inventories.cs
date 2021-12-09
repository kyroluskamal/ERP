using ERP.Models.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Inventory
{
    public class Inventories
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "NOT_VALID_PHONE_NUMBER")]
        public string MobilePhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "NOT_VALID_PHONE_NUMBER")]
        public string Telephone { get; set; }
        public string Notes { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool IsMainInventory { get; set; }

        [ForeignKey(nameof(AddedBy_UserId))]
        public ApplicationUser ApplicationUser { get; set; }
        public int? AddedBy_UserId { get; set; } //Not Required temporary
        public string AddedBy_UserName { get; set; }
        [NotMapped]
        public string Subdomain { get; set; }
    }
}
