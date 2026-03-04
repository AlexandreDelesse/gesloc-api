using GeslocApi.Application.DTOs;
using GeslocApi.Application.DTOs.Tenancies;
using GeslocApi.Application.Interfaces;
using GeslocApi.Domain.Entities;
using GeslocApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GeslocApi.Application.Services;

public class TenancyService : ITenancyService
{
    private readonly AppDbContext _context;

    public TenancyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TenancyDto>> GetAllAsync()
    {
        var tenancies = await _context.Tenancies.ToListAsync();
        return tenancies.Select(ToDto);
    }

    public async Task<TenancyDto?> GetByIdAsync(Guid id)
    {
        var tenancy = await _context.Tenancies.FindAsync(id);
        return tenancy == null ? null : ToDto(tenancy);
    }

    public async Task<IEnumerable<TenancyDto>> GetByPropertyAsync(Guid propertyId)
    {
        var tenancies = await _context.Tenancies
            .Where(t => t.PropertyId == propertyId)
            .ToListAsync();
        return tenancies.Select(ToDto);
    }

    public async Task<TenancyDto> CreateAsync(CreateTenancyDto dto)
    {
        var tenancy = new Tenancy
        {
            PropertyId = dto.PropertyId,
            Tenant = MapPerson(dto.Tenant),
            Guarantor = dto.Guarantor != null ? MapPerson(dto.Guarantor) : null,
            LegalFramework = dto.LegalFramework,
            PropertyUse = dto.PropertyUse,
            StartDate = dto.StartDate,
            DurationMonths = dto.DurationMonths,
            RentAmount = dto.RentAmount,
            ChargesAmount = dto.ChargesAmount,
            ChargesType = dto.ChargesType,
            PaymentDueDay = dto.PaymentDueDay,
            SecurityDeposit = dto.SecurityDeposit,
            Status = dto.Status,
            SignedDocument = dto.SignedDocument
        };
        _context.Tenancies.Add(tenancy);
        await _context.SaveChangesAsync();
        return ToDto(tenancy);
    }

    public async Task<TenancyDto?> UpdateAsync(Guid id, UpdateTenancyDto dto)
    {
        var tenancy = await _context.Tenancies.FindAsync(id);
        if (tenancy == null) return null;

        if (dto.Tenant != null) tenancy.Tenant = MapPerson(dto.Tenant);
        if (dto.Guarantor != null) tenancy.Guarantor = MapPerson(dto.Guarantor);
        if (dto.LegalFramework != null) tenancy.LegalFramework = dto.LegalFramework;
        if (dto.PropertyUse != null) tenancy.PropertyUse = dto.PropertyUse;
        if (dto.StartDate != null) tenancy.StartDate = dto.StartDate;
        if (dto.DurationMonths != null) tenancy.DurationMonths = dto.DurationMonths.Value;
        if (dto.RentAmount != null) tenancy.RentAmount = dto.RentAmount.Value;
        if (dto.ChargesAmount != null) tenancy.ChargesAmount = dto.ChargesAmount.Value;
        if (dto.ChargesType != null) tenancy.ChargesType = dto.ChargesType;
        if (dto.PaymentDueDay != null) tenancy.PaymentDueDay = dto.PaymentDueDay.Value;
        if (dto.SecurityDeposit != null) tenancy.SecurityDeposit = dto.SecurityDeposit.Value;
        if (dto.Status != null) tenancy.Status = dto.Status;
        if (dto.SignedDocument != null) tenancy.SignedDocument = dto.SignedDocument;

        await _context.SaveChangesAsync();
        return ToDto(tenancy);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var tenancy = await _context.Tenancies.FindAsync(id);
        if (tenancy == null) return false;
        _context.Tenancies.Remove(tenancy);
        await _context.SaveChangesAsync();
        return true;
    }

    private static Person MapPerson(PersonDto dto) => new()
    {
        LastName = dto.LastName,
        FirstName = dto.FirstName,
        Address = dto.Address != null ? new Address
        {
            Number = dto.Address.Number,
            Street = dto.Address.Street,
            PostCode = dto.Address.PostCode,
            City = dto.Address.City,
            Residence = dto.Address.Residence
        } : null
    };

    private static PersonDto MapPersonDto(Person p) => new()
    {
        LastName = p.LastName,
        FirstName = p.FirstName,
        Address = p.Address != null ? new AddressDto
        {
            Number = p.Address.Number,
            Street = p.Address.Street,
            PostCode = p.Address.PostCode,
            City = p.Address.City,
            Residence = p.Address.Residence
        } : null
    };

    private static TenancyDto ToDto(Tenancy t) => new()
    {
        Id = t.Id,
        PropertyId = t.PropertyId,
        Tenant = MapPersonDto(t.Tenant),
        Guarantor = t.Guarantor != null ? MapPersonDto(t.Guarantor) : null,
        LegalFramework = t.LegalFramework,
        PropertyUse = t.PropertyUse,
        StartDate = t.StartDate,
        DurationMonths = t.DurationMonths,
        RentAmount = t.RentAmount,
        ChargesAmount = t.ChargesAmount,
        ChargesType = t.ChargesType,
        PaymentDueDay = t.PaymentDueDay,
        SecurityDeposit = t.SecurityDeposit,
        Status = t.Status,
        SignedDocument = t.SignedDocument
    };
}
