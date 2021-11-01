using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Employee
{
    [Table("PaperImages")]
    public class EmployeeImages
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You have to add one image at least")]
        public byte[] Image { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employees Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
