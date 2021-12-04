using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Membership
{
    public class MembershipDescription
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Description { get; set; }

        public Memberships Memberships { get; set; }
        public int MembershipsId { get; set; }
    }
}
