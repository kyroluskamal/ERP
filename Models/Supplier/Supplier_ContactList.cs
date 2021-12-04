using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Supplier
{
    public class Supplier_ContactList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string LastName { get; set; }
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }

        [EmailAddress(ErrorMessage = "IncorrecEmail")]
        public string Email { get; set; }

        public Suppliers Suppliers { get; set; }
        public int SuppliersId { get; set; }
    }
}
