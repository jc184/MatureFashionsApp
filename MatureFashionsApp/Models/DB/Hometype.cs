using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Hometype
    {
        public Hometype()
        {
            Home = new HashSet<Home>();
        }

        public string HometypeCode { get; set; }
        public string HometypeDescription { get; set; }

        public virtual ICollection<Home> Home { get; set; }
    }
}
