namespace GeslocApi.Domain.Entities;

public class CandidateLink
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PropertyId { get; set; }
    public string PropertyName { get; set; } = "";
    public Guid Token { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;
    public string CreatedAt { get; set; } = "";
}
