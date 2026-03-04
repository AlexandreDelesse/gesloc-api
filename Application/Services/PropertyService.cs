using GeslocApi.Application.DTOs;
using GeslocApi.Application.DTOs.Properties;
using GeslocApi.Application.Interfaces;
using GeslocApi.Domain.Entities;
using GeslocApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GeslocApi.Application.Services;

public class PropertyService : IPropertyService
{
    private readonly AppDbContext _context;

    public PropertyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PropertyDto>> GetAllAsync()
    {
        var properties = await _context.Properties.ToListAsync();
        return properties.Select(ToDto);
    }

    public async Task<PropertyDto?> GetByIdAsync(Guid id)
    {
        var property = await _context.Properties.FindAsync(id);
        return property == null ? null : ToDto(property);
    }

    public async Task<PropertyDto> CreateAsync(CreatePropertyDto dto)
    {
        var property = FromCreateDto(dto);
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
        return ToDto(property);
    }

    public async Task<PropertyDto?> UpdateAsync(Guid id, UpdatePropertyDto dto)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null) return null;

        if (dto.Name != null) property.Name = dto.Name;
        if (dto.Surface != null) property.Surface = dto.Surface.Value;
        if (dto.Image != null) property.Image = dto.Image;
        if (dto.BuildingType != null) property.BuildingType = dto.BuildingType;
        if (dto.LegalRegime != null) property.LegalRegime = dto.LegalRegime;
        if (dto.ConstructionYear != null) property.ConstructionYear = dto.ConstructionYear;
        if (dto.RoomCount != null) property.RoomCount = dto.RoomCount;
        if (dto.Building != null) property.Building = dto.Building;
        if (dto.ApartmentNumber != null) property.ApartmentNumber = dto.ApartmentNumber;
        if (dto.Equipment != null) property.Equipment = dto.Equipment;
        if (dto.HeatingType != null) property.HeatingType = dto.HeatingType;
        if (dto.HotWaterType != null) property.HotWaterType = dto.HotWaterType;
        if (dto.InternetAccess != null) property.InternetAccess = dto.InternetAccess;
        if (dto.InternetType != null) property.InternetType = dto.InternetType;

        if (dto.Owner != null)
        {
            property.Owner.LastName = dto.Owner.LastName;
            property.Owner.FirstName = dto.Owner.FirstName;
            if (dto.Owner.Address != null)
                property.Owner.Address = MapAddress(dto.Owner.Address);
        }

        if (dto.Address != null)
        {
            property.Address.Number = dto.Address.Number;
            property.Address.Street = dto.Address.Street;
            property.Address.PostCode = dto.Address.PostCode;
            property.Address.City = dto.Address.City;
            property.Address.Residence = dto.Address.Residence;
        }

        await _context.SaveChangesAsync();
        return ToDto(property);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null) return false;
        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();
        return true;
    }

    private static Property FromCreateDto(CreatePropertyDto dto) => new()
    {
        Name = dto.Name,
        Surface = dto.Surface,
        Image = dto.Image,
        BuildingType = dto.BuildingType,
        LegalRegime = dto.LegalRegime,
        ConstructionYear = dto.ConstructionYear,
        RoomCount = dto.RoomCount,
        Building = dto.Building,
        ApartmentNumber = dto.ApartmentNumber,
        Equipment = dto.Equipment ?? [],
        HeatingType = dto.HeatingType,
        HotWaterType = dto.HotWaterType,
        InternetAccess = dto.InternetAccess,
        InternetType = dto.InternetType,
        Owner = MapPerson(dto.Owner),
        Address = MapAddress(dto.Address)
    };

    private static Person MapPerson(PersonDto dto) => new()
    {
        LastName = dto.LastName,
        FirstName = dto.FirstName,
        Address = dto.Address != null ? MapAddress(dto.Address) : null
    };

    private static Address MapAddress(AddressDto dto) => new()
    {
        Number = dto.Number,
        Street = dto.Street,
        PostCode = dto.PostCode,
        City = dto.City,
        Residence = dto.Residence
    };

    private static AddressDto MapAddressDto(Address a) => new()
    {
        Number = a.Number,
        Street = a.Street,
        PostCode = a.PostCode,
        City = a.City,
        Residence = a.Residence
    };

    private static PersonDto MapPersonDto(Person p) => new()
    {
        LastName = p.LastName,
        FirstName = p.FirstName,
        Address = p.Address != null ? MapAddressDto(p.Address) : null
    };

    private static PropertyDto ToDto(Property p) => new()
    {
        Id = p.Id,
        Name = p.Name,
        Surface = p.Surface,
        Image = p.Image,
        BuildingType = p.BuildingType,
        LegalRegime = p.LegalRegime,
        ConstructionYear = p.ConstructionYear,
        RoomCount = p.RoomCount,
        Building = p.Building,
        ApartmentNumber = p.ApartmentNumber,
        Equipment = p.Equipment,
        HeatingType = p.HeatingType,
        HotWaterType = p.HotWaterType,
        InternetAccess = p.InternetAccess,
        InternetType = p.InternetType,
        Owner = MapPersonDto(p.Owner),
        Address = MapAddressDto(p.Address)
    };
}
