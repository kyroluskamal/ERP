using ERP.Models.SystemsInErp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CutomFields
{
    public class Fields_Per_Service
    {
        public int Id { get; set; }
        public FieldsInSystem FieldsInSystem { get; set; }
        public int FieldsInSystemId { get; set; }
        public SystemsInERP SystemsInERP { get; set; }
        public int SystemsInERPId { get; set; }
    }
}
