using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Items
{
    public class ItemMainCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the name of the category")]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        [NotMapped]
        public string Subdomain { get; set; }
    }
}
