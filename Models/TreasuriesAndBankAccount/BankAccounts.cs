using System.ComponentModel.DataAnnotations;

namespace ERP.Models.TreasuriesAndBankAccount
{
    public class BankAccounts
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Write a name for this entry")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should write the bank name")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "You need write the bank account number")]
        public string BankAccountNo { get; set; }
    }
}
