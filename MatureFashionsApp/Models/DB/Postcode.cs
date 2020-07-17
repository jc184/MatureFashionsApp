using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Postcode
    {
        public string PostcodeArea { get; set; }
        public string PostcodeName { get; set; }
        public string FranchiseNo { get; set; }

        public virtual Franchise FranchiseNoNavigation { get; set; }
    }
}
