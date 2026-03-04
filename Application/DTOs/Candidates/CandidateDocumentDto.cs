namespace GeslocApi.Application.DTOs.Candidates;

public class CandidateDocumentDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = "";
    public string FileName { get; set; } = "";
    public string MimeType { get; set; } = "";
    public string File { get; set; } = "";
}
