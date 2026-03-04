using GeslocApi.Application.DTOs.CandidateLinks;

namespace GeslocApi.Application.Interfaces;

public interface ICandidateLinkService
{
    Task<CandidateLinkDto?> GetByTokenAsync(Guid token);
    Task<CandidateLinkDto?> GetByPropertyAsync(Guid propertyId);
    Task<CandidateLinkDto> CreateAsync(Guid propertyId, string propertyName);
    Task<CandidateLinkDto?> ToggleAsync(Guid propertyId);
}
