using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public interface ISaleRepository
    {
        IQueryable<Sale> Sales { get; }
        Sale Save(Sale sale);
        Sale Edit(Sale sale);
        void Remove(Sale sale);
        void DeleteAll();
    }
}