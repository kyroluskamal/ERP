using ERP.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class Units
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string WholeSaleUnit { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string RetailUnit { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "smallint")]
        [Range(1, int.MaxValue, ErrorMessage = "Negative_Value_ERROR")]
        public int NumberInWholeSale { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "smallint")]
        [Range(1, int.MaxValue, ErrorMessage = "Negative_Value_ERROR")]
        public int NumberInRetailSale { get; set; }

        [Column(TypeName = "smallint")]
        public int ConversionRate { get; set; }
        [NotMapped]
        public string Subdomain { get; set; }
    }
}
