namespace GeslocApi.Application.DTOs.CandidateLinks;

public class CandidateLinkDto
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public string PropertyName { get; set; } = "";
    public Guid Token { get; set; }
    public bool IsActive { get; set; }
    public string CreatedAt { get; set; } = "";
}
