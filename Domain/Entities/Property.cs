namespace GeslocApi.Domain.Entities;

public class Property
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public Person Owner { get; set; } = new();
    public Address Address { get; set; } = new();
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
