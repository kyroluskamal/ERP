﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Generals
{
    public class Currency
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You must add a currency name")]
        public string Name { get; set; }
    }
}