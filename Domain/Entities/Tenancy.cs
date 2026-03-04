namespace GeslocApi.Domain.Entities;

public class Tenancy
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PropertyId { get; set; }
    public Person Tenant { get; set; } = new();
    public Person? Guarantor { get; set; }
    public string LegalFramework { get; set; } = "meublé-loi-89";
    public string PropertyUse { get; set; } = "habitation";
    public string StartDate { get; set; } = "";
    public int DurationMonths { get; set; }
    public decimal RentAmount { get; set; }
    public decimal ChargesAmount { get; set; }
    public string ChargesType { get; set; } = "forfait";
    public int PaymentDueDay { get; set; } = 5;
    public decimal SecurityDeposit { get; set; }
    public string Status { get; set; } = "brouillon";
    public string? SignedDocument { get; set; }
}
