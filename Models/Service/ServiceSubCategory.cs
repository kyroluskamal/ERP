﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Service
{
    public class ServiceSubCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the name of the Subcategory")]
        [MaxLength(30)]
        public string Name { get; set; }
        public ServiceMainCategory ServiceMainCategory { get; set; }
        public int ServiceMainCategoryId { get; set; }
    }
}