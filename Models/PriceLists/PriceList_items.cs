using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.PriceLists
{
    public class PriceList_items
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, add the price")]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }

        public PriceList PriceList { get; set; }
        public int PriceListId { get; set; }
    }
}
