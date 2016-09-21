using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Stock { get; set; }
        public int BuyPrice { get; set; }
        public int SalePrice { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
