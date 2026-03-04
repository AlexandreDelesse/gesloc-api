namespace GeslocApi.Domain.Entities;

public class Candidate
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PropertyId { get; set; }
    public string LastName { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string EmploymentType { get; set; } = "";
    public decimal Income { get; set; }
    public bool HasGuarantor { get; set; }
    public string? GuarantorLastName { get; set; }
    public string? GuarantorFirstName { get; set; }
    public string? GuarantorEmploymentType { get; set; }
    public decimal? GuarantorIncome { get; set; }
    public string? CoverLetter { get; set; }
    public string Status { get; set; } = "en_attente";
    public string? Notes { get; set; }
    public string SubmittedAt { get; set; } = "";
    public bool GdprConsent { get; set; }
    // IsGuarantorDoc=false → documents candidat, IsGuarantorDoc=true → documents garant
    public List<CandidateDocument> Documents { get; set; } = new();
}
