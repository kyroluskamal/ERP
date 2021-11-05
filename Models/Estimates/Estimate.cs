﻿using ERP.Models.Employee;
using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Estimates
{
    public class Estimate
    {
        public int Id { get; set; }
        [Required]
        public string CurrentNumber { get; set; }
        
        [Required(ErrorMessage = "Please, write a name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Column(TypeName = "bit")]
        public bool IsForClient { get; set; }

        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreationDate { get; set; }

        [Column(TypeName = "bit")]
        public bool HashShippingFees { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }

        [Column(TypeName = "bit")]
        public bool HashNotes { get; set; }
        
        [Column(TypeName = "bit")]
        public bool IsForCategory { get; set; } 
        
        [Column(TypeName = "bit")]
        public bool IsForSubCatategory { get; set; }

        [Column(TypeName = "tinyint")]
        public int DaysToExpire { get; set; }

        [Column(TypeName = "tinyint")]
        public int EstimateFor { get; set; } // for service or Items

        [ForeignKey(nameof(AddBy_empId))]
        public Employees Employees { get; set; }
        public int? AddBy_empId { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public EmailsTemplates EmailsTemplates { get; set; }
        public int EmailsTemplatesId { get; set; }
    }
}