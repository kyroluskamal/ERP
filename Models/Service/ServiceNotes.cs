﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Service
{
    public class ServiceNotes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a note")]
        public string Notes { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
    }
}