﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class DiscountsPerItem
    {
        public int Id { get; set; }
        [Required]
        public int Discount { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool DiscountType { get; set; }

        public ItemsInSalesInvoices ItemsInSalesInvoices { get; set; }
        public int ItemsInSalesInvoicesId { get; set; }
    }
}