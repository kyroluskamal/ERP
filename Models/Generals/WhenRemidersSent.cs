using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Generals
{
    public class WhenRemidersSent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You need to add option")]
        public string WhenOption { get; set; }
    }
}
