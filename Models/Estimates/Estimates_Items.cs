﻿using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Estimates
{
    public class Estimates_Items
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal NewPrice { get; set; }

        public ItemVariants ItemVariants { get; set; }
        public int? ItemVariantsId { get; set; }
        public Estimate Estimate { get; set; }
        public int EstimateId { get; set; }
    }
}