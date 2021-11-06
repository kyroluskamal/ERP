using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Checks
{
    public class ReceivableCheck_Endorsement
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the name for endorsement")]
        public string EndorsedName { get; set; }

        public ReceivableCheck ReceivableCheck { get; set; }
        public int ReceivableCheckId { get; set; }
    }
}
