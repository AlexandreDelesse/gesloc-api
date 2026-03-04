using GeslocApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeslocApi.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Property> Properties => Set<Property>();
    public DbSet<Tenancy> Tenancies => Set<Tenancy>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<CandidateDocument> CandidateDocuments => Set<CandidateDocument>();
    public DbSet<CandidateLink> CandidateLinks => Set<CandidateLink>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>(b =>
        {
            b.HasKey(p => p.Id);
            b.OwnsOne(p => p.Owner, owner =>
            {
                owner.Property(o => o.LastName).HasColumnName("Owner_LastName");
                owner.Property(o => o.FirstName).HasColumnName("Owner_FirstName");
                owner.OwnsOne(o => o.Address, addr =>
                {
                    addr.Property(a => a.Number).HasColumnName("Owner_Address_Number");
                    addr.Property(a => a.Street).HasColumnName("Owner_Address_Street");
                    addr.Property(a => a.PostCode).HasColumnName("Owner_Address_PostCode");
                    addr.Property(a => a.City).HasColumnName("Owner_Address_City");
                    addr.Property(a => a.Residence).HasColumnName("Owner_Address_Residence");
                });
            });
            b.OwnsOne(p => p.Address, addr =>
            {
                addr.Property(a => a.Number).HasColumnName("Address_Number");
                addr.Property(a => a.Street).HasColumnName("Address_Street");
                addr.Property(a => a.PostCode).HasColumnName("Address_PostCode");
                addr.Property(a => a.City).HasColumnName("Address_City");
                addr.Property(a => a.Residence).HasColumnName("Address_Residence");
            });
        });

        modelBuilder.Entity<Tenancy>(b =>
        {
            b.HasKey(t => t.Id);
            b.OwnsOne(t => t.Tenant, tenant =>
            {
                tenant.Property(p => p.LastName).HasColumnName("Tenant_LastName");
                tenant.Property(p => p.FirstName).HasColumnName("Tenant_FirstName");
                tenant.OwnsOne(p => p.Address, addr =>
                {
                    addr.Property(a => a.Number).HasColumnName("Tenant_Address_Number");
                    addr.Property(a => a.Street).HasColumnName("Tenant_Address_Street");
                    addr.Property(a => a.PostCode).HasColumnName("Tenant_Address_PostCode");
                    addr.Property(a => a.City).HasColumnName("Tenant_Address_City");
                    addr.Property(a => a.Residence).HasColumnName("Tenant_Address_Residence");
                });
            });
            b.OwnsOne(t => t.Guarantor, guarantor =>
            {
                guarantor.Property(p => p.LastName).HasColumnName("Guarantor_LastName");
                guarantor.Property(p => p.FirstName).HasColumnName("Guarantor_FirstName");
                guarantor.OwnsOne(p => p.Address, addr =>
                {
                    addr.Property(a => a.Number).HasColumnName("Guarantor_Address_Number");
                    addr.Property(a => a.Street).HasColumnName("Guarantor_Address_Street");
                    addr.Property(a => a.PostCode).HasColumnName("Guarantor_Address_PostCode");
                    addr.Property(a => a.City).HasColumnName("Guarantor_Address_City");
                    addr.Property(a => a.Residence).HasColumnName("Guarantor_Address_Residence");
                });
            });
        });

        modelBuilder.Entity<Candidate>(b =>
        {
            b.HasKey(c => c.Id);
            b.HasMany(c => c.Documents)
             .WithOne()
             .HasForeignKey(d => d.CandidateId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CandidateDocument>(b =>
        {
            b.HasKey(d => d.Id);
        });
    }
}
