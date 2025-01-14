﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.COCs
{
    public class ClientStatus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(10, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string StatusName { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(7, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Color { get; set; }
        [ForeignKey(nameof(COCId))]
        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
