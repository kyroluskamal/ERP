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
        [Required(ErrorMessage = "Please, add the supplier's first name")]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please, add the supplier's first name")]
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"+?^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobilePhone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Suppliers Suppliers { get; set; }
        public int SuppliersId { get; set; }
    }
}
