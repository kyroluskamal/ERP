using System.ComponentModel.DataAnnotations;

namespace ERP.Areas.Owners.Models
{
    public class Currency
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string CurrencyName { get; set; }
        public Country Country { get; set; }
        public int? CountryId { get; set; }
    }
}
