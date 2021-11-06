using System.ComponentModel.DataAnnotations;

namespace ERP.Models.CutomFields
{
    public class Field_Choices
    {
        public int Id { get; set; }
        [Required]
        public string ChoiceName { get; set; }
        [Required]
        public string Choicevalue { get; set; }
        public Fields_Properties Fields_Properties { get; set; }
        public int Fields_PropertiesId { get; set; }
    }
}
