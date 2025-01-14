﻿using ERP.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class ServicesInSalesInvices
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal SubtotalPerItem { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public string Decriptions { get; set; }

        public Services Services { get; set; }
        public int ServicesId { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int? SalesInvoicesId { get; set; }
    }
}
