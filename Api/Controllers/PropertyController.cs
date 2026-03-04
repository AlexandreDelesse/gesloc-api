using GeslocApi.Application.DTOs.Properties;
using GeslocApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{

    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePropertyDto cmd)
    {
        var property = await _propertyService.CreateAsync(cmd);
        return Ok(property);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var properties = await _propertyService.GetAllAsync();
        return Ok(properties);
    }
}

// app.MapPost("/porperties", async (Property p, AppDbContext db) =>
// {
//     db.Properties.Add(p);
//     await db.SaveChangesAsync();
//     return Results.Created($"/properties/{p.Id}", p);
// });