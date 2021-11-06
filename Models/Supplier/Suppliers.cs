using ERP.Models.Employee;
using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Supplier
{
    public class Suppliers
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, add the supplier's buisness name")]
        [MaxLength(50)]
        public string BusinessName { get; set; }
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
        public string TaxID { get; set; }
        public string CR { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Please, add the starting balance or 0 if there is no start balance")]
        [Column(TypeName = "Money")]
        public decimal OpeningBalance { get; set; }
        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }

        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
    }
}
