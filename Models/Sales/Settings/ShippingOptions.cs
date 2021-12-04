using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales.Settings
{
    public class ShippingOptions
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal Fees { get; set; }

        public TaxSettings TaxSettings { get; set; }
        public int TaxSettingsId { get; set; }
    }
}
