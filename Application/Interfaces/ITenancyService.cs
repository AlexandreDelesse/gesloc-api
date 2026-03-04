using GeslocApi.Application.DTOs.Tenancies;

namespace GeslocApi.Application.Interfaces;

public interface ITenancyService
{
    Task<IEnumerable<TenancyDto>> GetAllAsync();
    Task<TenancyDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<TenancyDto>> GetByPropertyAsync(Guid propertyId);
    Task<TenancyDto> CreateAsync(CreateTenancyDto dto);
    Task<TenancyDto?> UpdateAsync(Guid id, UpdateTenancyDto dto);
    Task<bool> DeleteAsync(Guid id);
}
