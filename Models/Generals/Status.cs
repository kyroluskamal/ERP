using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Generals
{
    public class Status
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Color { get; set; }
        [Column(TypeName = "bit")]
        public bool OpenedOrClosed { get; set; }
    }
}
