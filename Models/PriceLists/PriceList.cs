using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.PriceLists
{
    public class PriceList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a name for the price list")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
