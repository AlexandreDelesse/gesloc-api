using GeslocApi.Application.DTOs;

namespace GeslocApi.Application.DTOs.Properties;

public class UpdatePropertyDto
{
    public string? Name { get; set; }
    public PersonDto? Owner { get; set; }
    public AddressDto? Address { get; set; }
    public double? Surface { get; set; }
    public string? Image { get; set; }
    public string? BuildingType { get; set; }
    public string? LegalRegime { get; set; }
    public int? ConstructionYear { get; set; }
    public int? RoomCount { get; set; }
    public string? Building { get; set; }
    public string? ApartmentNumber { get; set; }
    public string[]? Equipment { get; set; }
    public string? HeatingType { get; set; }
    public string? HotWaterType { get; set; }
    public bool? InternetAccess { get; set; }
    public string? InternetType { get; set; }
}
