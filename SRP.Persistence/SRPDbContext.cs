using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using SRP.Domain;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence
{
    public class SRPDbContext : DbContext
    {
        public SRPDbContext(DbContextOptions<SRPDbContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Move this to a separate class
            modelBuilder.Entity<Address>().ToTable("Address", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<AddressType>().ToTable("AddressType", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Country>().ToTable("Country", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Province>().ToTable("Province", t => t.ExcludeFromMigrations());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SRPDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
