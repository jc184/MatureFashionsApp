using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Shows
    {
        public Shows()
        {
            Saleitem = new HashSet<Saleitem>();
        }

        public string FranchiseNo { get; set; }
        public int HomeNo { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowTime { get; set; }
        public decimal ShowTotalSale { get; set; }

        public virtual Franchise FranchiseNoNavigation { get; set; }
        public virtual Home HomeNoNavigation { get; set; }
        public virtual ICollection<Saleitem> Saleitem { get; set; }
    }
}
