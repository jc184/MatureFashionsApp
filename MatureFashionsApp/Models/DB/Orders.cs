using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Orders
    {
        public Orders()
        {
            Invoice = new HashSet<Invoice>();
            Orderline = new HashSet<Orderline>();
        }

        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string FranchiseNo { get; set; }

        public virtual Franchise FranchiseNoNavigation { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Orderline> Orderline { get; set; }
    }
}
