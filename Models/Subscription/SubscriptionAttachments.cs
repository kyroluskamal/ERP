using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Subscription
{
    public class SubscriptionAttachments
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public byte[] Attachments { get; set; }

        public Subscriptions Subscriptions { get; set; }
        public int SubscriptionsId { get; set; }
    }
}
