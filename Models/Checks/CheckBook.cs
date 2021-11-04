using ERP.Models.Generals;
using ERP.Models.TreasuriesAndBankAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Checks
{
    public class CheckBook
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the check number")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "You must enter number only")]
        public int CheckBookNo { get; set; }

        [Required(ErrorMessage = "Please, write the first serial number")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "You must enter number only")]
        public int FirstSerial { get; set; }
        [Required(ErrorMessage = "Please, write the Last serial number")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "You must enter number only")]
        public int LastSerial { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }

        public Currency Currency { get; set; }
        public int? CurrencyId { get; set; }

        public BankAccounts BankAccounts { get; set; }
        public int BankAccountsId { get; set; }
    }
}
