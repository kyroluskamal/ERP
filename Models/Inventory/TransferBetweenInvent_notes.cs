using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Inventory
{
    public class TransferBetweenInvent_notes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Notes { get; set; }

        public TransferBetweenInvent TransferBetweenInvent { get; set; }
        public int TransferBetweenInventId { get; set; }
    }
}
