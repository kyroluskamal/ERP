using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Generals
{
    public class Currency
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must add a currency name")]
        public string Name { get; set; }
    }
}
