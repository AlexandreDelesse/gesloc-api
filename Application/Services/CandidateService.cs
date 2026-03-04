using GeslocApi.Application.DTOs;
using GeslocApi.Application.DTOs.Candidates;
using GeslocApi.Application.Interfaces;
using GeslocApi.Domain.Entities;
using GeslocApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GeslocApi.Application.Services;

public class CandidateService : ICandidateService
{
    private readonly AppDbContext _context;

    public CandidateService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CandidateDto>> GetByPropertyAsync(Guid propertyId)
    {
        var candidates = await _context.Candidates
            .Include(c => c.Documents)
            .Where(c => c.PropertyId == propertyId)
            .ToListAsync();
        return candidates.Select(ToDto);
    }

    public async Task<CandidateDto?> GetByIdAsync(Guid id)
    {
        var candidate = await _context.Candidates
            .Include(c => c.Documents)
            .FirstOrDefaultAsync(c => c.Id == id);
        return candidate == null ? null : ToDto(candidate);
    }

    public async Task<CandidateDto> SubmitAsync(SubmitCandidateDto dto)
    {
        var docs = dto.Documents.Select(d => new CandidateDocument
        {
            Type = d.Type,
            FileName = d.FileName,
            MimeType = d.MimeType,
            File = d.File,
            IsGuarantorDoc = false
        }).ToList();

        if (dto.HasGuarantor && dto.Guarantor != null)
        {
            var guarantorDocs = dto.Guarantor.Documents.Select(d => new CandidateDocument
            {
                Type = d.Type,
                FileName = d.FileName,
                MimeType = d.MimeType,
                File = d.File,
                IsGuarantorDoc = true
            });
            docs.AddRange(guarantorDocs);
        }

        var candidate = new Candidate
        {
            PropertyId = dto.PropertyId,
            LastName = dto.Person.LastName,
            FirstName = dto.Person.FirstName,
            Email = dto.Person.Email,
            Phone = dto.Person.Phone,
            EmploymentType = dto.EmploymentType,
            Income = dto.Income,
            HasGuarantor = dto.HasGuarantor,
            GuarantorLastName = dto.Guarantor?.Person.LastName,
            GuarantorFirstName = dto.Guarantor?.Person.FirstName,
            GuarantorEmploymentType = dto.Guarantor?.EmploymentType,
            GuarantorIncome = dto.Guarantor?.Income,
            CoverLetter = dto.CoverLetter,
            Status = "en_attente",
            SubmittedAt = DateTime.UtcNow.ToString("o"),
            GdprConsent = dto.GdprConsent,
            Documents = docs
        };

        _context.Candidates.Add(candidate);
        await _context.SaveChangesAsync();
        return ToDto(candidate);
    }

    public async Task<CandidateDto?> UpdateAsync(Guid id, UpdateCandidateDto dto)
    {
        var candidate = await _context.Candidates
            .Include(c => c.Documents)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (candidate == null) return null;

        if (dto.Status != null) candidate.Status = dto.Status;
        if (dto.Notes != null) candidate.Notes = dto.Notes;

        await _context.SaveChangesAsync();
        return ToDto(candidate);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var candidate = await _context.Candidates
            .Include(c => c.Documents)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (candidate == null) return false;
        _context.Candidates.Remove(candidate);
        await _context.SaveChangesAsync();
        return true;
    }

    private static CandidateDto ToDto(Candidate c)
    {
        var candidateDocs = c.Documents
            .Where(d => !d.IsGuarantorDoc)
            .Select(MapDocDto)
            .ToList();

        var guarantorDocs = c.Documents
            .Where(d => d.IsGuarantorDoc)
            .Select(MapDocDto)
            .ToList();

        GuarantorProfileDto? guarantor = null;
        if (c.HasGuarantor)
        {
            guarantor = new GuarantorProfileDto
            {
                Person = new PersonDto
                {
                    LastName = c.GuarantorLastName ?? "",
                    FirstName = c.GuarantorFirstName ?? ""
                },
                EmploymentType = c.GuarantorEmploymentType ?? "",
                Income = c.GuarantorIncome ?? 0,
                Documents = guarantorDocs
            };
        }

        return new CandidateDto
        {
            Id = c.Id,
            PropertyId = c.PropertyId,
            Person = new CandidatePersonDto
            {
                LastName = c.LastName,
                FirstName = c.FirstName,
                Email = c.Email,
                Phone = c.Phone
            },
            EmploymentType = c.EmploymentType,
            Income = c.Income,
            Documents = candidateDocs,
            HasGuarantor = c.HasGuarantor,
            Guarantor = guarantor,
            CoverLetter = c.CoverLetter,
            Status = c.Status,
            Notes = c.Notes,
            SubmittedAt = c.SubmittedAt,
            GdprConsent = c.GdprConsent
        };
    }

    private static CandidateDocumentDto MapDocDto(CandidateDocument d) => new()
    {
        Id = d.Id,
        Type = d.Type,
        FileName = d.FileName,
        MimeType = d.MimeType,
        File = d.File
    };
}
