using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.COCs
{
    public class Individual_COC
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(10, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string FirstName { get; set; }
        [MaxLength(10, ErrorMessage = "MaxLengthExceeded_ERROR")]
        [Required(ErrorMessage = "Required_field")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "tinyint")]
        public int Gender { get; set; }
        [ForeignKey(nameof(COCId))]
        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
