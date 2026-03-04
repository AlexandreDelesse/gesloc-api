using GeslocApi.Application.DTOs;

namespace GeslocApi.Application.DTOs.Candidates;

public class GuarantorProfileDto
{
    public PersonDto Person { get; set; } = new();
    public string EmploymentType { get; set; } = "";
    public decimal Income { get; set; }
    public List<CandidateDocumentDto> Documents { get; set; } = new();
}
