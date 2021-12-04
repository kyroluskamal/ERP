using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Generals
{
    public class EmailsTemplates
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string TemplateName { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string TemplateContent { get; set; }
    }
}
