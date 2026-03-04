namespace GeslocApi.Domain.Entities;

public class Person
{
    public string LastName { get; set; } = "";
    public string FirstName { get; set; } = "";
    public Address? Address { get; set; }
}
