using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.COCs
{
    public class ClientNotes
    {
        public int Id { get; set; }
        public string Note { get; set; }
        [ForeignKey(nameof(COCId))]
        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
