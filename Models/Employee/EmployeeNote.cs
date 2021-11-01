using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Employee
{
    public class EmployeeNote
    {
        [Key]
        public int Id { get; set; }
        public string Note { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }
        public int UserId { get; set; }
    }
}
