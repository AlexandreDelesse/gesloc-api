using GeslocApi.Application.DTOs.Payments;
using GeslocApi.Application.Interfaces;
using GeslocApi.Domain.Entities;
using GeslocApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GeslocApi.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly AppDbContext _context;

    public PaymentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PaymentDto>> GetByTenancyAsync(Guid tenancyId)
    {
        var payments = await _context.Payments
            .Where(p => p.TenancyId == tenancyId)
            .ToListAsync();
        return payments.Select(ToDto);
    }

    public async Task<IEnumerable<PaymentDto>> CreateBatchAsync(List<CreatePaymentDto> dtos)
    {
        var payments = dtos.Select(dto => new Payment
        {
            TenancyId = dto.TenancyId,
            Period = dto.Period,
            RentAmount = dto.RentAmount,
            ChargesAmount = dto.ChargesAmount,
            DueDate = dto.DueDate,
            PaidAt = dto.PaidAt,
            Status = dto.Status
        }).ToList();

        _context.Payments.AddRange(payments);
        await _context.SaveChangesAsync();
        return payments.Select(ToDto);
    }

    public async Task<PaymentDto?> UpdateAsync(Guid id, UpdatePaymentDto dto)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null) return null;

        if (dto.Status != null) payment.Status = dto.Status;
        if (dto.PaidAt != null) payment.PaidAt = dto.PaidAt;

        await _context.SaveChangesAsync();
        return ToDto(payment);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null) return false;
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
        return true;
    }

    private static PaymentDto ToDto(Payment p) => new()
    {
        Id = p.Id,
        TenancyId = p.TenancyId,
        Period = p.Period,
        RentAmount = p.RentAmount,
        ChargesAmount = p.ChargesAmount,
        DueDate = p.DueDate,
        PaidAt = p.PaidAt,
        Status = p.Status
    };
}
