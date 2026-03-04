using Microsoft.EntityFrameworkCore;

namespace GeslocApi.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<PropertyTable> Properties => Set<PropertyTable>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PropertyTable>().OwnsOne(p => p.Address);
    }

}

public class PropertyTable
{
    public Guid PropertyId { get; set; }
    public string Name { get; set; }
    public AddressTable Address { get; set; }
}

public class AddressTable
{
    public Guid AdressId { get; set; }
    public string Line1 { get; set; }
    public string Line { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }

}