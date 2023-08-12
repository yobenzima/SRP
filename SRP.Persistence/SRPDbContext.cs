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

        public DbSet<Address> Address { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<ApplicantType> ApplicantType { get; set; }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Domain.Entities.Application> Application { get; set; }
        public DbSet<BEECertificationType> BEECertificationType { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Domain.Entities.File> File { get; set; }
        public DbSet<FileUserLink> FileUserLink { get; set; }
        public DbSet<LegalEntity> LegalEntity { get; set; }
        public DbSet<LegalEntityAddressLink> LegalEntityAddressLink { get; set; }
        public DbSet<LegalEntityContactLink> LegalEntityContactLink { get; set; }
        public DbSet<LegalEntityType> LegalEntityType { get; set; }
        public DbSet<LocalMunicipality> LocalMunicipality { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SRPDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
