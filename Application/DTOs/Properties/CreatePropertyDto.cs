using GeslocApi.Domain.Entities;

namespace GeslocApi.Application.DTOs.Properties;

public class CreatePropertyDto
{
    public string Name { get; set; } = "";
    public AddressDto Address { get; set; } = new AddressDto();
    public int Surface { get; set; } = 0;

}