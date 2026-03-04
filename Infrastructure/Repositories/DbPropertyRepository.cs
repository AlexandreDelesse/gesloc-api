using GeslocApi.Application.Interfaces;
using GeslocApi.Domain.Entities;
using GeslocApi.Infrastructure.Persistence;

namespace GeslocApi.Infrastructure.Repositories;

public class DbPropertyRepository : IPropertyRepository
{
    AppDbContext _dbContext;
    public DbPropertyRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public Property CreateProperty()
    {
        throw new NotImplementedException();
    }

    public bool DeleteProperty(Guid propertyId)
    {
        throw new NotImplementedException();
    }

    public List<Property> GetProperties()
    {
        throw new NotImplementedException();
    }

    public Property? GetPropertyByGuid(Guid propertyId)
    {
        throw new NotImplementedException();
    }
}