using inferback.Domain.ViewEntities;
using inferback.Service.Interfaces;
using InferTest;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Description; 

[ApiController]
[Route("api/description/[controller]")]
public class HttpPostDescription : ControllerBase {
    private readonly IDescriptionService _descriptionService;

    public HttpPostDescription(IDescriptionService descriptionService) {
        _descriptionService = descriptionService;
    }

    [HttpPost("create-description/{id}")]
    public async Task<IActionResult> CreateReport([FromBody] Script script, int id) {
        if (script == null) return BadRequest("Request have to include script");

        var response = await _descriptionService.CreateDescription(script, id);

        if (response.StatusCode == Domain.Enum.StatusCode.OK) return Ok(response.Data);

        return NoContent();
    }
}
