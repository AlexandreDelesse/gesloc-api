namespace GeslocApi.Application.DTOs.Candidates;

public class SubmitCandidateDto
{
    public Guid PropertyId { get; set; }
    public CandidatePersonDto Person { get; set; } = new();
    public string EmploymentType { get; set; } = "";
    public decimal Income { get; set; }
    public List<CandidateDocumentDto> Documents { get; set; } = new();
    public bool HasGuarantor { get; set; }
    public GuarantorProfileDto? Guarantor { get; set; }
    public string? CoverLetter { get; set; }
    public bool GdprConsent { get; set; }
}
