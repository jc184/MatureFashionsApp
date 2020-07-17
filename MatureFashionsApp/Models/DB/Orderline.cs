using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Orderline
    {
        public string OrderNo { get; set; }
        public string ItemNo { get; set; }
        public int OrderQuantity { get; set; }

        public virtual Item ItemNoNavigation { get; set; }
        public virtual Orders OrderNoNavigation { get; set; }
    }
}
