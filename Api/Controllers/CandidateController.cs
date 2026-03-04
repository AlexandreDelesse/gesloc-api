using GeslocApi.Application.DTOs.Candidates;
using GeslocApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class CandidateController : ControllerBase
{
    private readonly ICandidateService _service;

    public CandidateController(ICandidateService service)
    {
        _service = service;
    }

    [HttpGet("api/properties/{propertyId:guid}/candidates")]
    public async Task<IActionResult> GetByProperty(Guid propertyId)
    {
        return Ok(await _service.GetByPropertyAsync(propertyId));
    }

    [HttpGet("api/candidates/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost("api/candidates")]
    public async Task<IActionResult> Submit(SubmitCandidateDto dto)
    {
        var result = await _service.SubmitAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("api/candidates/{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateCandidateDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpDelete("api/candidates/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
