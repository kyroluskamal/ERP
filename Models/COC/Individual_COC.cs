using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.COC
{
    public class Individual_COC
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Your first name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Your last name is required")]
        public string LastName { get; set; }
        
        [DataType(DataType.Date)]
        [Column(TypeName ="Date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Employee gender is required ")]
        [Column(TypeName = "tinyint")]
        public int Gender { get; set; }
        [ForeignKey(nameof(COCId))]
        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
