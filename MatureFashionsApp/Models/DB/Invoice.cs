using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Invoice
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDateDue { get; set; }
        public decimal InvoiceNet { get; set; }
        public string FranchiseNo { get; set; }
        public string OrderNo { get; set; }

        public virtual Franchise FranchiseNoNavigation { get; set; }
        public virtual Orders OrderNoNavigation { get; set; }
    }
}
