using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Generals
{
    public class Status
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You need to add status name")]
        public string StatusName { get; set; }
        [Required(ErrorMessage = "Specify a color")]
        public string Color { get; set; }
        [Column(TypeName = "bit")]
        public bool OpenedOrClosed { get; set; }
    }
}
