using GeslocApi.Application.DTOs;
using GeslocApi.Application.DTOs.Properties;
using GeslocApi.Application.Interfaces;
using GeslocApi.Infrastructure.Persistence;
using GeslocApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeslocApi.Application.Services;

public class PropertyService : IPropertyService
{
    private readonly AppDbContext _context;

    public PropertyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PropertyDto> CreateAsync(CreatePropertyDto cmd)
    {
        var property = new Property
        {
            Address = new Address
            {
                City = cmd.Address.City,
                Country = cmd.Address.Country,
                PostalCode = cmd.Address.PostalCode,
                Street = cmd.Address.Street
            },
        };

        _context.Properties.Add(property);
        await _context.SaveChangesAsync();

        return new PropertyDto
        {
            Id = property.Id,
            Address = new AddressDto
            {
                City = property.Address.City,
                Country = property.Address.Country,
                PostalCode = property.Address.PostalCode,
                Street = property.Address.Street
            },
            Name = property.Name,
            Surface = property.Surface
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var property = await _context.Properties.FindAsync(id);

        if (property == null)
            return false;

        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<PropertyDto>> GetAllAsync()
    {
        return await _context.Properties
                .Select(p => new PropertyDto
                {
                    Id = p.Id,
                    Address = new AddressDto
                    {
                        City = p.Address.City,
                        Country = p.Address.Country,
                        PostalCode = p.Address.PostalCode,
                        Street = p.Address.Street
                    },
                    Name = p.Name,
                    Surface = p.Surface
                })
                .ToListAsync();
    }

    // public async Task<PropertyDto> GetByIdAsync(Guid id)
    // {
    //      var property = await _context.Properties.FindAsync(id);

    //         if (property == null)
    //             return null;

    //         return new PropertyDto
    //         {
    //             Id = property.Id,
    //             Address = property.Address,
    //             Informations = property.Informations
    //         };
    // }
}