using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Saleitem
    {
        public string FranchiseNo { get; set; }
        public int HomeNo { get; set; }
        public DateTime ShowDate { get; set; }
        public string ItemNo { get; set; }
        public int SaleQuantity { get; set; }

        public virtual Item ItemNoNavigation { get; set; }
        public virtual Shows Shows { get; set; }
    }
}
