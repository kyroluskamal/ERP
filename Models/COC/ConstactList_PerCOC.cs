using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.COC
{
    public class ConstactList_PerCOC
    {

        public COC COC { get; set; }
        [Key, Column(Order = 0)]
        public int COCId { get; set; }
        public COC_ContactList COC_ContactList { get; set; }
        [Key, Column(Order = 1)]
        public int COC_ContactListId { get; set; }
    }
}
