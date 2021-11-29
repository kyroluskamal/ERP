using ERP.Models.COCs;

namespace ERP.Models.CreditNotes
{
    public class CreditNtotes_Client
    {
        public int Id { get; set; }
        public COC COC { get; set; }
        public int COCId { get; set; }

        public CreditNote CreditNote { get; set; }
        public int? CreditNoteId { get; set; }
    }
}
