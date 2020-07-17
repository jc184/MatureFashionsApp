using System;
using System.Collections.Generic;

namespace MatureFashionsApp.Models.DB
{
    public partial class Item
    {
        public Item()
        {
            Orderline = new HashSet<Orderline>();
            Saleitem = new HashSet<Saleitem>();
        }

        public string ItemNo { get; set; }
        public string ItemDescription { get; set; }
        public string ItemGender { get; set; }
        public string ItemColour { get; set; }
        public string ItemSize { get; set; }
        public decimal ItemWholesalePrice { get; set; }
        public decimal ItemRetailPrice { get; set; }

        public virtual ICollection<Orderline> Orderline { get; set; }
        public virtual ICollection<Saleitem> Saleitem { get; set; }
    }
}
