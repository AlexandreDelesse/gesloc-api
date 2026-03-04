using GeslocApi.Domain.Entities;

namespace GeslocApi.Application.DTOs;

public class PropertyDto
{
    public Guid Id { get; set; } = new Guid();

    public int Surface { get; set; } = 0;
    public string Name { get; set; } = "";
    public AddressDto Address { get; set; } = new AddressDto();


}