using GeslocApi.Application.DTOs.Tenancies;
using GeslocApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class TenancyController : ControllerBase
{
    private readonly ITenancyService _service;

    public TenancyController(ITenancyService service)
    {
        _service = service;
    }

    [HttpGet("api/tenancies")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("api/tenancies/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("api/properties/{propertyId:guid}/tenancies")]
    public async Task<IActionResult> GetByProperty(Guid propertyId)
    {
        return Ok(await _service.GetByPropertyAsync(propertyId));
    }

    [HttpPost("api/tenancies")]
    public async Task<IActionResult> Create(CreateTenancyDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("api/tenancies/{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateTenancyDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpDelete("api/tenancies/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
