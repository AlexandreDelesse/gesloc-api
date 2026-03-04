using GeslocApi.Application.DTOs.CandidateLinks;
using GeslocApi.Application.Interfaces;
using GeslocApi.Domain.Entities;
using GeslocApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GeslocApi.Application.Services;

public class CandidateLinkService : ICandidateLinkService
{
    private readonly AppDbContext _context;

    public CandidateLinkService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CandidateLinkDto?> GetByTokenAsync(Guid token)
    {
        var link = await _context.CandidateLinks
            .FirstOrDefaultAsync(l => l.Token == token);
        return link == null ? null : ToDto(link);
    }

    public async Task<CandidateLinkDto?> GetByPropertyAsync(Guid propertyId)
    {
        var link = await _context.CandidateLinks
            .FirstOrDefaultAsync(l => l.PropertyId == propertyId);
        return link == null ? null : ToDto(link);
    }

    public async Task<CandidateLinkDto> CreateAsync(Guid propertyId, string propertyName)
    {
        var link = new CandidateLink
        {
            PropertyId = propertyId,
            PropertyName = propertyName,
            Token = Guid.NewGuid(),
            IsActive = true,
            CreatedAt = DateTime.UtcNow.ToString("o")
        };
        _context.CandidateLinks.Add(link);
        await _context.SaveChangesAsync();
        return ToDto(link);
    }

    public async Task<CandidateLinkDto?> ToggleAsync(Guid propertyId)
    {
        var link = await _context.CandidateLinks
            .FirstOrDefaultAsync(l => l.PropertyId == propertyId);
        if (link == null) return null;

        link.IsActive = !link.IsActive;
        await _context.SaveChangesAsync();
        return ToDto(link);
    }

    private static CandidateLinkDto ToDto(CandidateLink l) => new()
    {
        Id = l.Id,
        PropertyId = l.PropertyId,
        PropertyName = l.PropertyName,
        Token = l.Token,
        IsActive = l.IsActive,
        CreatedAt = l.CreatedAt
    };
}
