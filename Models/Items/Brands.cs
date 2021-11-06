using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Items
{
    public class Brands
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the brand name")]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
