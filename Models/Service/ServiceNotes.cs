using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Service
{
    public class ServiceNotes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a note")]
        public string Notes { get; set; }
        public Services Service { get; set; }
        public int ServiceId { get; set; }
    }
}
