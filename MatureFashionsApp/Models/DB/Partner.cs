using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Partner
    {
        public string FranchiseNo { get; set; }
        public string PartnerName { get; set; }

        public virtual Franchise FranchiseNoNavigation { get; set; }
    }
}
