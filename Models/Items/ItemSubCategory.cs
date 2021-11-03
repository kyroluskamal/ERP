using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Items
{
    public class ItemSubCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the name of the Subcategory")]
        [MaxLength(30)]
        public string Name { get; set; }
        public ItemMainCategory ItemMainCategory { get; set; }
        public int ItemMainCategoryId { get; set; }
    }
}
