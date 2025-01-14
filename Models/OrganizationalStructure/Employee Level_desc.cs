﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.OrganizationalStructure
{
    public class EmployeeLevel_desc
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Description { get; set; }
        [ForeignKey(nameof(EmployessLevelId))]
        public EmployeeLevel EmployeeLevel { get; set; }
        public int EmployessLevelId { get; set; }
    }
}
