using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class Units
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the wholesale unit")]
        [MaxLength(20)]
        public string WholeSaleUnit { get; set; }
        [Required(ErrorMessage = "Please, write the wholesale unit")]
        [MaxLength(20)]
        public string RetailUnit { get; set; }
        [Required(ErrorMessage = "Enter the amount of pieces in the Wholesale unit")]
        [Column(TypeName = "smallint")]
        public int NumberInWholeSale { get; set; }
        [Required(ErrorMessage = "Enter the amount of pieces in the Retail unit")]
        [Column(TypeName = "smallint")]
        public int NumberInRetailSale { get; set; }
    }
}
