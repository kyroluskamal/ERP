using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.TreasuriesAndBankAccount
{
    public class BankAccount_Description
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public BankAccounts BankAccounts { get; set; }
        public int BankAccountId { get; set; }
    }
}
