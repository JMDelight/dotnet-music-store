using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Sale
    {
        public Sale(int itemId, string userId, int saleId = 0)
        {
            ItemId = itemId;
            SaleId = saleId;
            UserId = userId;
        }
        public Sale() { }

        [Key]
        public int SaleId { get; set; }
        public int ItemId { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Item Item { get; set; }
    }
}
