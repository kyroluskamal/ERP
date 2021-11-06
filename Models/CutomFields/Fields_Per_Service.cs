using ERP.Models.SystemsInErp;

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
