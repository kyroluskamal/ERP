using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class Brands
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]

        public ICollection<ItemBrands> ItemBrands;
        public string Name { get; set; }
        [NotMapped]
        public string Subdomain { get; set; }
    }
}
