using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Payroll
{
    public class ContractsAttachments
    {
        public int Id { get; set; }
        [Required]
        public byte[] Attachments { get; set; }
        public Contract_Per_Emp Contract_Per_Emp { get; set; }
        public int Contract_Per_EmpId { get; set; }
    }
}
