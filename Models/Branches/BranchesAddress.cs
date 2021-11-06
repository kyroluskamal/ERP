using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Branches
{
    public class BranchesAddress
    {
        public int Id { get; set; }
        public string BuildingNo { get; set; }
        public string FlatNo { get; set; }
        [Required(ErrorMessage = "You need to add any info for the address")]
        public string AddressLine_1 { get; set; }
        public string AddressLine_2 { get; set; }
        [Required(ErrorMessage = "Add the postal code")]
        public string PostalCode { get; set; }

        [ForeignKey(nameof(BranchId))]
        public BusinessBranches BusinessBranches { get; set; }
        public int BranchId { get; set; }
    }
}
