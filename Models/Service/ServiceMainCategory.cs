using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Service
{
    public class ServiceMainCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the name of the category")]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
