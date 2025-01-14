﻿using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Checks
{
    public class CheckBook_Notes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Notes { get; set; }

        public CheckBook CheckBook { get; set; }
        public int CheckBookId { get; set; }
    }
}
