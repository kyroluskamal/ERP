using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.COC.COCSettings
{
    public class COC_Settings
    {
        public int Id { get; set; }
        [Column(TypeName = "bit")]
        public bool CanViewProfile { get; set; }

        [Column(TypeName = "bit")]
        public bool CanEditProfile { get; set; }

        [Column(TypeName = "bit")]
        public bool CanViewNotesOrAttachments { get; set; }

        [Column(TypeName = "bit")]
        public bool CanViewAndPayInvoices { get; set; }

        [Column(TypeName = "bit")]
        public bool CanViewAndApproveEstimates { get; set; }

        [Column(TypeName = "bit")]
        public bool CanViewWorkOrders { get; set; }

        [Column(TypeName = "bit")]
        public bool CanViewAppoinments { get; set; }

        [Column(TypeName = "bit")]
        public bool DiableBooking { get; set; }

        [Column(TypeName = "bit")]
        public bool DisableBookingCancelation { get; set; }

        [Column(TypeName = "bit")]
        public bool DisableClientOnlineAccess { get; set; }

        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
