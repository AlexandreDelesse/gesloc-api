using GeslocApi.Application.DTOs;
using GeslocApi.Application.DTOs.Properties;

namespace GeslocApi.Application.Interfaces;

public interface IPropertyService
{
    Task<IEnumerable<PropertyDto>> GetAllAsync();
    Task<PropertyDto?> GetByIdAsync(Guid id);
    Task<PropertyDto> CreateAsync(CreatePropertyDto dto);
    Task<PropertyDto?> UpdateAsync(Guid id, UpdatePropertyDto dto);
    Task<bool> DeleteAsync(Guid id);
}
