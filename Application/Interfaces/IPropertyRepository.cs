using GeslocApi.Domain.Entities;

namespace GeslocApi.Application.Interfaces;

public interface IPropertyRepository
{
    List<Property> GetProperties();
    Property? GetPropertyByGuid(Guid propertyId);
    Property CreateProperty();
    bool DeleteProperty(Guid propertyId);
}