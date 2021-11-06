using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Service
{
    public class ServiceDescription
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a description")]
        public string Description { get; set; }
        public Services Service { get; set; }
        public int ServiceId { get; set; }
    }
}
