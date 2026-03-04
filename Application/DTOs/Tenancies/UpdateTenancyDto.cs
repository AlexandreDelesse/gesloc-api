using GeslocApi.Application.DTOs;

namespace GeslocApi.Application.DTOs.Tenancies;

public class UpdateTenancyDto
{
    public PersonDto? Tenant { get; set; }
    public PersonDto? Guarantor { get; set; }
    public string? LegalFramework { get; set; }
    public string? PropertyUse { get; set; }
    public string? StartDate { get; set; }
    public int? DurationMonths { get; set; }
    public decimal? RentAmount { get; set; }
    public decimal? ChargesAmount { get; set; }
    public string? ChargesType { get; set; }
    public int? PaymentDueDay { get; set; }
    public decimal? SecurityDeposit { get; set; }
    public string? Status { get; set; }
    public string? SignedDocument { get; set; }
}
