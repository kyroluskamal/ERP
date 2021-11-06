using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Checks
{
    public class PayableCheck_Description
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a description")]
        public string Description { get; set; }

        public PayableCheck PayableCheck { get; set; }
        public int PayableCheckId { get; set; }
    }
}
