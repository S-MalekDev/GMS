using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.CommandModel
{
    public class AddSubscriptionDetailCommandModel
    {
        public int SubscriptionID { get; set; }
        public int SubscriptionTypeID { get; set; }
        public int? SubscriptionOfferID { get; set; } = null;
    }
}
