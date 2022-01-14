using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Items
{
    public class InternalNotes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Notes { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
