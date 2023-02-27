using inferback.DAL.Interfaces;
using inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Description; 

[ApiController]
[Route("api/description/[controller]")]
public class HttpDeleteDescription : ControllerBase {
    private readonly IDescriptionService _descriptionService;

    public HttpDeleteDescription(IDescriptionService descriptionService) {
        _descriptionService = descriptionService;
    }

    [HttpDelete("delete-description/{id}")]
    public async Task<IActionResult> DeleteDescription(int id) {
        if (id == 0) return BadRequest("Request have to include id");

        var response = await _descriptionService.DeleteDescription(id);

        if (response.StatusCode == Domain.Enum.StatusCode.OK) 
            return Ok("Object 'description' delete successfully");

        return BadRequest("Object 'description' did not delete");
    }
}