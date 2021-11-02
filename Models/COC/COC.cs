using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.COC
{
    public class COC
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You need to choose your account type")]
        [Column(TypeName ="bool")]
        public bool ClientType { get; set; }

        [Required(ErrorMessage = "You need to specify the client credit limit or write 0")]
        public int CreditLimit { get; set; }

        [Required(ErrorMessage = "You need to specify the client credit limit or write 0")]
        public int CreditPeriodLimit { get; set; }
        [Column(TypeName = "Money")]
        public decimal Balance { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName ="Date")]
        public DateTime BalanceStartDate { get; set; }
        
        public bool HasEstimates { get; set; }
        public bool HasCategory { get; set; }
        public bool HasNote { get; set; }
        public string NationalId { get; set; }

        public string Location { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }

        public string Telephone { get; set; }
        public byte[] ProfileImage { get; set; }
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        [Column(TypeName ="tinyint")]
        public int InvoicingMethod { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
        public int CountryId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }
        public int UserId { get; set; }

        public ICollection<ConstactList_PerCOC> COC_Contacts { get; set; }
    }
}
