using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Franchisor
    {
        public Franchisor()
        {
            Franchise = new HashSet<Franchise>();
        }

        public string FranchisorNo { get; set; }
        public string FranchisorName { get; set; }
        public string FranchisorAddress { get; set; }
        public string FranchisorPostcode { get; set; }
        public string FranchisorTel { get; set; }
        public string FranchisorFax { get; set; }

        public virtual ICollection<Franchise> Franchise { get; set; }
    }
}
