using System.ComponentModel.DataAnnotations;

namespace ERP.Models.CutomFields
{
    public class FieldsInSystem
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
