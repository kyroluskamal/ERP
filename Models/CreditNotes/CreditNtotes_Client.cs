using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CreditNotes
{
    public class CreditNtotes_Client
    {
        public int Id { get; set; }
        public ERP.Models.COC.COC COC { get; set; }
        public int COCId { get; set; }

        public CreditNote CreditNote { get; set; }
        public int CreditNoteId { get; set; }
    }
}
