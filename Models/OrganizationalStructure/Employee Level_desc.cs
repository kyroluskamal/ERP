﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.OrganizationalStructure
{
    public class EmployeeLevel_desc
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a description")]
        public string Description { get; set; }
        [ForeignKey(nameof(EmployessLevelId))]
        public EmployeeLevel EmployeeLevel { get; set; }
        public int EmployessLevelId { get; set; }
    }
}