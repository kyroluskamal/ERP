using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models.COCs
{
    public class COC_ContactList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(10, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string FirstName { get; set; }
        [MaxLength(10, ErrorMessage = "MaxLengthExceeded_ERROR")]
        [Required(ErrorMessage = "Required_field")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }
        [EmailAddress(ErrorMessage = "IncorrecEmail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Telephone { get; set; }
        public ICollection<ConstactList_PerCOC> COC_Contacts { get; set; }
    }
}
