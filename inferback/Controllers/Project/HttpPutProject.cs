using inferback.Domain.ViewEntities;
using inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Project; 

[ApiController]
[Route("api/project/[controller]")]
public class HttpPutProject : ControllerBase {
    private readonly IProjectService _projectService;
    
    public HttpPutProject(IProjectService projectService) {
        _projectService = projectService;
    }
    
    [HttpPut("edit-project")]
    public async Task<IActionResult> EditProject(int id, [FromBody] ProjectView entity) {
        if (entity == null) {
            return BadRequest("Request have to include entity");
        }

        var response = await _projectService.UpdateProject(id, entity);

        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return Ok("Object 'Project' edited successfully");
        }

        return BadRequest("Object 'Project' did not edit");
    }
}