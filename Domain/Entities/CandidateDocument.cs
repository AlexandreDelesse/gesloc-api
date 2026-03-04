namespace GeslocApi.Domain.Entities;

public class CandidateDocument
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CandidateId { get; set; }
    public bool IsGuarantorDoc { get; set; }
    public string Type { get; set; } = "";
    public string FileName { get; set; } = "";
    public string MimeType { get; set; } = "";
    public string File { get; set; } = "";
}
