using inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Project; 

[ApiController]
[Route("api/project/[controller]")]
public class HttpGetProject : ControllerBase {
    private readonly IProjectService _projectService;

    public HttpGetProject(IProjectService projectService) {
        _projectService = projectService;
    }

    [HttpGet("get-projects")]
    public async Task<IActionResult> GetProjects() {
        var response = await _projectService.GetProjects();

        if (response.Result == "Get projects. Projects did not found") {
            return BadRequest("Nothing to found");
        }

        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return Ok(response.Data);
        }

        return NoContent();
    }

    [HttpGet("get-project/{id}")]
    public async Task<IActionResult> GetProject(int id) {
        var response = await _projectService.GetProject(id);

        if (response.Result == "Get project. Project did not found") {
            return BadRequest("Nothing to found");
        }

        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return Ok(response.Data);
        }

        return NoContent();
    }
}