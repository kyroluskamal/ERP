using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Items
{
    public class ItemMainCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the name of the category")]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
