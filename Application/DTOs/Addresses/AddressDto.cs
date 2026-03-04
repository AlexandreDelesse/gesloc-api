namespace GeslocApi.Application.DTOs;

public class AddressDto
{
    public int? Number { get; set; }
    public string Street { get; set; } = "";
    public string PostCode { get; set; } = "";
    public string City { get; set; } = "";
    public string? Residence { get; set; }
}
