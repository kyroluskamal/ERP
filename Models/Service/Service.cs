using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Service
{
    public class Service
    {
        public int Id { get; set; }
        public bool IsOnline { get; set; }
        public bool HasDescription { get; set; }
        public bool HasSpecialOffer { get; set; }
        public bool HasNote { get; set; }
        public int AddByUser { get; set; }
        public ServiceSubCategory ServiceSubCategory { get; set; }
        public int? ServiceSubCategoryId { get; set; }
    }
}
