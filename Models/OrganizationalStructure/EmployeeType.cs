using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.OrganizationalStructure
{
    public class EmployeeType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, Write a level")]
        [MaxLength(20)]
        public string EmployeeTypeName { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
    }
}
