using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.CutomFields
{
    public class Fields_validation_Foreach_Service
    {
        public int Id { get; set; }
        [Column(TypeName = "tinyint")]
        //1 = Required,  0 = Not required,  -1=Not applicable
        public int IsRequired { get; set; }
        [Column(TypeName = "tinyint")]
        //1 = Unique,  0 = Not Unique,  -1=Not applicable
        public int IsUnique { get; set; }

        [Column(TypeName = "tinyint")]
        //1 = Filter,  0 = Not Filter,  -1=Not applicable
        public int FilterByThisField { get; set; }
        [Column(TypeName = "tinyint")]
        //1 = List,  0 = Not List,  -1=Not applicable
        public int ListByThisField { get; set; }
        [Column(TypeName = "bit")]
        public bool HasMinAndMaxNumber { get; set; }
        [Column(TypeName = "bit")]
        public bool HasMinAndMaxDate { get; set; }
        public Fields_Per_Service Fields_Per_Service { get; set; }
        public int Fields_Per_ServiceId { get; set; }
    }
}
