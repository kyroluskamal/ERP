using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Service
{
    public class ServiceDescription
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Description { get; set; }
        public Services Service { get; set; }
        public int ServiceId { get; set; }
    }
}
