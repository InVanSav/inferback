using inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Project; 

[ApiController]
[Route("api/project/[controller]")]
public class HttpDeleteProject : ControllerBase {
    private readonly IProjectService _projectService;

    public HttpDeleteProject(IProjectService projectService) {
        _projectService = projectService;
    }
    
    [HttpDelete("delete-project/{id}")]
    public async Task<IActionResult> DeleteProject(int id) {
        if (id == 0) {
            return BadRequest("Request have to include id");
        }

        var response = await _projectService.DeleteProject(id);

        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return Ok("Object 'project' delete successfully");
        }

        return BadRequest("Object 'project' did not delete");

    }

}