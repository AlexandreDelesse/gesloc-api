using GeslocApi.Application.DTOs.Candidates;

namespace GeslocApi.Application.Interfaces;

public interface ICandidateService
{
    Task<IEnumerable<CandidateDto>> GetByPropertyAsync(Guid propertyId);
    Task<CandidateDto?> GetByIdAsync(Guid id);
    Task<CandidateDto> SubmitAsync(SubmitCandidateDto dto);
    Task<CandidateDto?> UpdateAsync(Guid id, UpdateCandidateDto dto);
    Task<bool> DeleteAsync(Guid id);
}
