using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Generals
{
    public class EmailsTemplates
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You need to add a name for the template")]
        public string TemplateName { get; set; }
        [Required(ErrorMessage = "You need to add the template")]
        public string TemplateContent { get; set; }
    }
}
