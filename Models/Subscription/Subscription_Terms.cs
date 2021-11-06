using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Subscription
{
    public class Subscription_Terms
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write Terms")]
        public string Terms { get; set; }

        public Subscriptions Subscriptions { get; set; }
        public int SubscriptionsId { get; set; }
    }
}
