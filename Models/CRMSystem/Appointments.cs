using ERP.Models.COCs;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.CRMSystem
{
    public class Appointments
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime AppointmentDate { get; set; }
        public int Duration { get; set; }

        [Column(TypeName = "bit")]
        public bool IsSharedWithClient { get; set; }
        [Column(TypeName = "bit")]
        public bool IsRepeated { get; set; }
        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }
        [Column(TypeName = "bit")]
        public bool IsAssignedToStaff { get; set; }

        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
