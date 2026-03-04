using GeslocApi.Application.DTOs;

namespace GeslocApi.Domain.Entities;

public class Address
{
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string Country { get; set; } = "";

    public static implicit operator Address(AddressDto v)
    {
        throw new NotImplementedException();
    }
}