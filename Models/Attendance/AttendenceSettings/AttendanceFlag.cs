﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class AttendanceFlag
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a name for the holidaies list")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, choose a color")]
        [MaxLength(7)]
        public string Color { get; set; }

        public string Description { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        public string Conditions { get; set; }
        public string Formula { get; set; }
    }
}
