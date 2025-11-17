using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.CommandModel
{
    public class AddSubscriptionCommandModel
    {
        public int MemberID { get; set; }
        public int SubscriptionTypeID { get; set; }
        public int? SubscriptionOfferID { get; set; } = null;
        public int CreatedByUserID { get; set; }
        public DateOnly StartDate { get; set; }
    }
}
