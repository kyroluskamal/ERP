using System.ComponentModel.DataAnnotations;

namespace ERP.Models.COCs
{
    public class COC_category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You need to specify a category name")]
        [MaxLength(15)]
        public string CategoryName { get; set; }
    }
}
