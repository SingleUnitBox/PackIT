using Microsoft.EntityFrameworkCore;
using PackIT.Infrastructure.EF.Config;
using PackIT.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Context
{
    internal class ReadDbContext : DbContext
    {
        public DbSet<PackingListReadModel> PackingLists { get; set; }
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
            modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
        }
    }
}
