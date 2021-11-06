using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Items
{
    public class ItemDescription
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a description")]
        public string Description { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
