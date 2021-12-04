using System.ComponentModel.DataAnnotations;

namespace ERP.Models.CutomFields
{
    public class FieldsInSystem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }
    }
}
