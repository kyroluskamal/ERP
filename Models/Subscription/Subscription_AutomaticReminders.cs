using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Subscription
{
    public class Subscription_AutomaticReminders
    {
        public int Id { get; set; }
        public Subscriptions Subscriptions { get; set; }
        public int SubscriptionsId { get; set; }

        public AutomaticReminders AutomaticReminders { get; set; }
        public int AutomaticRemindersId { get; set; }
    }
}
