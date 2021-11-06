using ERP.Models.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.PriceLists
{
    public class PriceList_Services
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, add the price")]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        public Services Services { get; set; }
        public int ServicesId { get; set; }

        public PriceList PriceList { get; set; }
        public int PriceListId { get; set; }
    }
}
