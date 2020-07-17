using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Franchise
    {
        public Franchise()
        {
            Invoice = new HashSet<Invoice>();
            Orders = new HashSet<Orders>();
            Partner = new HashSet<Partner>();
            Postcode = new HashSet<Postcode>();
            Shows = new HashSet<Shows>();
        }

        public string FranchiseNo { get; set; }
        public string FranchiseName { get; set; }
        public string FranchiseAddress { get; set; }
        public string FranchisePostcode { get; set; }
        public string FranchiseTel { get; set; }
        public string FranchiseFax { get; set; }
        public DateTime FranchiseStartdate { get; set; }
        public string FranchisorNo { get; set; }

        public virtual Franchisor FranchisorNoNavigation { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Partner> Partner { get; set; }
        public virtual ICollection<Postcode> Postcode { get; set; }
        public virtual ICollection<Shows> Shows { get; set; }
    }
}
