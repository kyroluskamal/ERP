﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.COC
{
    public class Category_PerClient
    {
        [ForeignKey(nameof(COCId))]
        public COC COC { get; set; }
        public int COCId { get; set; }

        [ForeignKey(nameof(COC_categoryId))]
        public COC_category COC_category { get; set; }
        public int COC_categoryId { get; set; }
    }
}