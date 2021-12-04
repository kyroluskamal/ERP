using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Generals
{
    public class Currency
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Name { get; set; }
    }
}
