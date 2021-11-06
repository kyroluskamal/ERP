using System.ComponentModel.DataAnnotations;

namespace ERP.Models.TreasuriesAndBankAccount
{
    public class Treasury_description
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public Treasuries Treasuries { get; set; }
        public int TreasuryId { get; set; }
    }
}
