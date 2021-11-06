using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Generals
{
    public class Actions
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You need to specify the action name")]
        public string Name { get; set; }
    }
}
