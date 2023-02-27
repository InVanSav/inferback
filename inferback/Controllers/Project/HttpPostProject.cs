using inferback.Domain.ViewEntities;
using inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Project;

[ApiController]
[Route("api/project/[controller]")]
public class HttpPostProject : ControllerBase {
    private readonly IProjectService _projectService;

    public HttpPostProject(IProjectService projectService) {
        _projectService = projectService;
    }

    [HttpPost("create-project")]
    public async Task<IActionResult> CreateReport([FromBody] ProjectView entity) {
        if (entity == null) return BadRequest("Request have to include entity");

        var response = await _projectService.CreateProject(entity);

        if (response.StatusCode == Domain.Enum.StatusCode.OK) return Ok(response.Data);

        return NoContent();
    }
}