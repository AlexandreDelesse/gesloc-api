namespace GeslocApi.Application.DTOs;

public class PropertyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public PersonDto Owner { get; set; } = new();
    public AddressDto Address { get; set; } = new();
    public double Surface { get; set; }
    public string? Image { get; set; }
    public string? BuildingType { get; set; }
    public string? LegalRegime { get; set; }
    public int? ConstructionYear { get; set; }
    public int? RoomCount { get; set; }
    public string? Building { get; set; }
    public string? ApartmentNumber { get; set; }
    public string[] Equipment { get; set; } = [];
    public string? HeatingType { get; set; }
    public string? HotWaterType { get; set; }
    public bool? InternetAccess { get; set; }
    public string? InternetType { get; set; }
}
