﻿using ERP.Models.Employee;
using ERP.Models.Generals;
using ERP.Models.TreasuriesAndBankAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Payroll
{
    public class Loans
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime ApplicationDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime InstallmentStartDate { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }
        [Column(TypeName = "Money")]
        public decimal InstallmentAmount { get; set; }

        [Column(TypeName = "bit")]
        public bool IsPaidFromPaySlip { get; set; }
        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public int InstallmentCount { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public int PeriodOfInstallment { get; set; }

        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public Treasuries Treasuries { get; set; }
        public int TreasuriesId { get; set; }
    }
}
