﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Checks
{
    public class PayableCheck
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime IssueDate { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "You must enter number only")]
        public int CheckNo { get; set; }
        [Required]
        //AccountId in the chart of accounts in which we will add these money
        public int ReceivedFromAccountId { get; set; }
        //مفيش حساب هناخد منه هنا لان تلقائي حساب البنك هو اللى هيتاخد منه
        //ورقم حساب البنك هنلاقيه مربوط بالCheckbook
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(50)]
        public string NameOnCheck { get; set; }

        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }
    }
}
