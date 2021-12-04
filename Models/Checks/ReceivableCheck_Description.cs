using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Checks
{
    public class ReceivableCheck_Description
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Description { get; set; }

        public ReceivableCheck ReceivableCheck { get; set; }
        public int ReceivableCheckId { get; set; }
    }
}
