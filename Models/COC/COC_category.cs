using System.ComponentModel.DataAnnotations;

namespace ERP.Models.COCs
{
    public class COC_category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(15, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string CategoryName { get; set; }
    }
}
