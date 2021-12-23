using System.ComponentModel.DataAnnotations;

namespace ERP.Areas.Owners.Models
{
    public class Currency
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
