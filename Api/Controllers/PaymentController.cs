using GeslocApi.Application.DTOs.Payments;
using GeslocApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _service;

    public PaymentController(IPaymentService service)
    {
        _service = service;
    }

    [HttpGet("api/tenancies/{tenancyId:guid}/payments")]
    public async Task<IActionResult> GetByTenancy(Guid tenancyId)
    {
        return Ok(await _service.GetByTenancyAsync(tenancyId));
    }

    [HttpPost("api/tenancies/{tenancyId:guid}/payments/batch")]
    public async Task<IActionResult> CreateBatch(Guid tenancyId, List<CreatePaymentDto> dtos)
    {
        foreach (var dto in dtos)
            dto.TenancyId = tenancyId;
        var result = await _service.CreateBatchAsync(dtos);
        return Ok(result);
    }

    [HttpPut("api/payments/{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdatePaymentDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpDelete("api/payments/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
