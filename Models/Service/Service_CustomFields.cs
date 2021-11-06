using ERP.Models.CutomFields;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Service
{
    public class Service_CustomFields
    {
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }

        public Services Service { get; set; }
        public int ServiceId { get; set; }
        public Fields_Per_Service Fields_Per_Service { get; set; }
        public int Fields_Per_ServiceId { get; set; }
    }
}
