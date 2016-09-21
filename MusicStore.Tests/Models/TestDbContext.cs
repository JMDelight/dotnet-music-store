using Microsoft.EntityFrameworkCore;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Tests.Models
{
    public class TestDbContext : ApplicationDbContext
    {
        public override DbSet<Item> Items { get; set; }
        public override DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MusicStoreTest;integrated security = True");
        }
    }
}
