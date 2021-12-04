using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Service
{
    public class ServiceSubCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }
        public ServiceMainCategory ServiceMainCategory { get; set; }
        public int ServiceMainCategoryId { get; set; }
    }
}
