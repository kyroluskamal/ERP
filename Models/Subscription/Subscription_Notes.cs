using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Subscription
{
    public class Subscription_Notes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write Notes")]
        public string Notes { get; set; }

        public Subscriptions Subscriptions { get; set; }
        public int SubscriptionsId { get; set; }
    }
}
