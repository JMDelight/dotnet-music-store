using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class EFSaleRepository : ISaleRepository
    {
        public EFSaleRepository(ApplicationDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new ApplicationDbContext();
            }
            else
            {
                this.db = connection;
            }
        }

        ApplicationDbContext db = new ApplicationDbContext();
        public IQueryable<Sale> Sales
        { get { return db.Sales; } }
        public Sale Save(Sale sale)
        {
            db.Sales.Add(sale);
            Item soldItem = db.Items.FirstOrDefault(i => i.ItemId == sale.ItemId);
            soldItem.Stock--;
            db.Entry(soldItem).State = EntityState.Modified;
            db.SaveChanges();
            return sale;
        }

        public Sale Edit(Sale sale)
        {
            db.Entry(sale).State = EntityState.Modified;
            db.SaveChanges();
            return sale;
        }

        public void Remove(Sale sale)
        {
            db.Sales.Remove(sale);
            Item returnedItem = db.Items.FirstOrDefault(i => i.ItemId == sale.ItemId);
            returnedItem.Stock++;
            db.Entry(returnedItem).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteAll()
        {
            db.Sales.RemoveRange(Sales);
            db.SaveChanges();
        }
    }
}
