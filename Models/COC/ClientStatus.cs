using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.COC
{
    public class ClientStatus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a status name")]
        [MaxLength(10)]
        public string StatusName { get; set; }
        [Required(ErrorMessage = "Please, select a color")]
        [MaxLength(7)]
        public string Color { get; set; }
        [ForeignKey(nameof(COCId))]
        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
