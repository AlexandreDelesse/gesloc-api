namespace GeslocApi.Application.DTOs;

public class PersonDto
{
    public string LastName { get; set; } = "";
    public string FirstName { get; set; } = "";
    public AddressDto? Address { get; set; }
}
