namespace GeslocApi.Application.DTOs.Payments;

public class CreatePaymentDto
{
    public Guid TenancyId { get; set; }
    public string Period { get; set; } = "";
    public decimal RentAmount { get; set; }
    public decimal ChargesAmount { get; set; }
    public string DueDate { get; set; } = "";
    public string? PaidAt { get; set; }
    public string Status { get; set; } = "en_attente";
}
