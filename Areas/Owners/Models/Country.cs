using System.ComponentModel.DataAnnotations;

namespace ERP.Areas.Owners.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryNameCode { get; set; } //eg: EG = Egypt
        public string CountryName { get; set; }
        public string PhoneCode { get; set; }
        public Currency Currency { get; set; }
    }
}
