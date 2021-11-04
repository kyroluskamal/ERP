﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class VacationsType_LeaveType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a name for the leave type")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, choose a color")]
        [MaxLength(20)]
        public string Color { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "smallint")]
        public int MaxDaysAllowedPerYear { get; set; }
        [Column(TypeName = "tinyint")]
        public int MaximumContinuousDaysApplicable { get; set; }
        [Column(TypeName ="tinyint")]
        public int ApplicableAfter_HowManyDays { get; set; }
        public bool IsNeedPermission { get; set; }
    }
}