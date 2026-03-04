using GeslocApi.Application.DTOs.Payments;

namespace GeslocApi.Application.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetByTenancyAsync(Guid tenancyId);
    Task<IEnumerable<PaymentDto>> CreateBatchAsync(List<CreatePaymentDto> dtos);
    Task<PaymentDto?> UpdateAsync(Guid id, UpdatePaymentDto dto);
    Task<bool> DeleteAsync(Guid id);
}
