using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Checks
{
    public class ReceivableCheck
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the amount of money received by this check")]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime IssueDate { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Please, write the check number")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "You must enter number only")]
        public int CheckNo { get; set; }
        [Required]
        //AccountId in the chart of accounts in which we will add these money
        public int ReceivedFromAccountId { get; set; }
        [Required]
        //AccountId in the chart of accounts from which we will take these money
        public int CollectAccountId { get; set; }
        [Required(ErrorMessage = "Please, write the name written on the check")]
        [MaxLength(50)]
        public string NameOnCheck { get; set; }
        [Column(TypeName = "bit")]
        //تظهير الشيك اللى هو بنكتب اسم شخص تاني مستفيد من الشيك
        public bool IsEndorsed { get; set; }
        [Column(TypeName = "bit")]
        public bool HasAttachments { get; set; }
    }
}
