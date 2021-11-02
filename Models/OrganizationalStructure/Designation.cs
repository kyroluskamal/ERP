using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.OrganizationalStructure
{
    public class Designation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, Write a designation")]
        [MaxLength(20)]
        public string DesignationName { get; set; }
        public bool IsActive { get; set; }
    }
}
