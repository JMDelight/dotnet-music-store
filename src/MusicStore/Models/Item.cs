using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Item
    {
        public Item() { }
        public Item(string itemName, int buyPrice, int salePrice, int stock, int itemId = 0)
        {
            ItemId = itemId;
            BuyPrice = buyPrice;
            SalePrice = salePrice;
            Stock = stock;
            ItemName = itemName;
        }
        public override bool Equals(object obj)
        {
            if(!( obj is Item))
            {
                return false;
            }
            else
            {
                Item newItem = (Item)obj;
                return (this.ItemId.Equals(newItem.ItemId) 
                    && this.ItemName.Equals(newItem.ItemName)
                    && this.Stock.Equals(newItem.Stock)
                    && this.BuyPrice.Equals(newItem.BuyPrice)
                    && this.SalePrice.Equals(newItem.SalePrice));
            }
        }
        public override int GetHashCode()
        {
            return this.ItemId.GetHashCode();
        }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Stock { get; set; }
        public int BuyPrice { get; set; }
        public int SalePrice { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
