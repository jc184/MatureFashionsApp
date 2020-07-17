using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Home
    {
        public Home()
        {
            Shows = new HashSet<Shows>();
        }

        public int HomeNo { get; set; }
        public string HomeName { get; set; }
        public string HometypeCode { get; set; }
        public string HomeAddress { get; set; }
        public string HomePostcode { get; set; }
        public string HomeTel { get; set; }

        public virtual Hometype HometypeCodeNavigation { get; set; }
        public virtual ICollection<Shows> Shows { get; set; }
    }
}
