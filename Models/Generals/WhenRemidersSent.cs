using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Generals
{
    public class WhenRemidersSent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string WhenOption { get; set; }
    }
}
