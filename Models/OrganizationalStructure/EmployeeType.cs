using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public bool IsActive { get; set; }
        public bool HasDescription { get; set; }
    }
}
