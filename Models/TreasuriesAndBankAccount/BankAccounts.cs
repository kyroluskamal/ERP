using System.ComponentModel.DataAnnotations;

namespace ERP.Models.TreasuriesAndBankAccount
{
    public class BankAccounts
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public string BankAccountNo { get; set; }
    }
}
