namespace GeslocApi.Domain.Entities;

public class Property
{
    public Guid Id { get; set; } = new Guid();
    public Address Address { get; set; } = new Address();
    public int Surface { get; set; } = 0;
    public string Name { get; set; } = "";
}