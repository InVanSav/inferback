using Inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Project; 

[ApiController]
[Route("api/project/[controller]")]
public class HttpPutProject : ControllerBase {
    private readonly IProjectService _projectService;
    
    public HttpPutProject(IProjectService projectService) {
        _projectService = projectService;
    }
    
    [HttpPut("edit-project/{id}/{entity}")]
    public async Task<IActionResult> EditProject(int id, Inferback.Domain.Entity.Project entity) {
        if (id == null || entity == null) {
            return BadRequest("Request have to include entity");
        }

        var response = await _projectService.UpdateProject(id, entity);

        if (response.StatusCode == Inferback.Domain.Enum.StatusCode.OK) {
            return Ok("Object 'Project' edited successfully");
        }

        return BadRequest("Object 'Project' did not edit");
    }
}