using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.WorkOrder
{
    public class WorkOrders
    {
        public int Id { get; set; }
        [Required]
        [Index]
        public string CurrentNumber { get; set; }
        [Required(ErrorMessage = "Please, add title")]
        [MaxLength(50)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FinishDate { get; set; }

        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
        [Column(TypeName = "bit")]
        public bool HasCustomFields { get; set; }
        [Column(TypeName = "bit")]
        public bool HasCustomAttachments { get; set; }
        [Column(TypeName = "bit")]
        public bool IsItAssignedToEmp { get; set; }

        [Column(TypeName = "Money")]
        public decimal Budget { get; set; }

        public Currency Currency { get; set; }
        public int? CurrencyId { get; set; }
    }
}
