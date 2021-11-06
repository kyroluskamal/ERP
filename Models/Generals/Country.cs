using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Generals
{
    public class Country
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must add a country name")]
        public string Name { get; set; }
    }
}
