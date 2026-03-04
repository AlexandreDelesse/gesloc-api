using GeslocApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class CandidateLinkController : ControllerBase
{
    private readonly ICandidateLinkService _service;

    public CandidateLinkController(ICandidateLinkService service)
    {
        _service = service;
    }

    [HttpGet("api/candidate-links/{token:guid}")]
    public async Task<IActionResult> GetByToken(Guid token)
    {
        var result = await _service.GetByTokenAsync(token);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("api/properties/{propertyId:guid}/candidate-link")]
    public async Task<IActionResult> GetByProperty(Guid propertyId)
    {
        var result = await _service.GetByPropertyAsync(propertyId);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost("api/properties/{propertyId:guid}/candidate-link")]
    public async Task<IActionResult> Create(Guid propertyId, [FromBody] CreateLinkRequest request)
    {
        var result = await _service.CreateAsync(propertyId, request.PropertyName);
        return Ok(result);
    }

    [HttpPatch("api/properties/{propertyId:guid}/candidate-link/toggle")]
    public async Task<IActionResult> Toggle(Guid propertyId)
    {
        var result = await _service.ToggleAsync(propertyId);
        return result == null ? NotFound() : Ok(result);
    }
}

public record CreateLinkRequest(string PropertyName);
