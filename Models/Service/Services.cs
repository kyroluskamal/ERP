using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Service
{
    public class Services
    {
        public int Id { get; set; }
        [Column(TypeName = "bit")]
        public bool IsOnline { get; set; }
        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }
        [Column(TypeName = "bit")] 
        public bool HasSpecialOffer { get; set; }
        [Column(TypeName = "bit")] 
        public bool HasNote { get; set; }
        public int AddByUser { get; set; }
        public ServiceSubCategory ServiceSubCategory { get; set; }
        public int? ServiceSubCategoryId { get; set; }
    }
}
