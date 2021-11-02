using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.COC
{
    public class COC_ContactList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Your first name is required")]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [MaxLength(10)]
        [Required(ErrorMessage = "Your last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="You need to add a telephone number")]
        public string Telephone { get; set; }
        public ICollection<ConstactList_PerCOC> COC_Contacts { get; set; }
    }
}
