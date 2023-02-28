using inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Description; 

[ApiController]
[Route("api/description/[controller]")]
public class HttpGetDescription : ControllerBase {
    private readonly IDescriptionService _descriptionService;

    public HttpGetDescription(IDescriptionService descriptionService) {
        _descriptionService = descriptionService;
    }
    
    [HttpGet("get-descriptions-of-report/{id}")]
    public async Task<IActionResult> GetDescriptionsOfReport(int id) {
        var descriptions = 
            await _descriptionService.GetDescriptionsOfReport(id);

        if (descriptions.Result == "Get descriptions of report. Descriptions did not found") 
            return BadRequest("Nothing to found");

        if (descriptions.StatusCode == Domain.Enum.StatusCode.OK) 
            return Ok(descriptions.Data);

        return NoContent();
    }
    
    [HttpGet("get-descriptions-name-report_id/{id}/{name}")]
    public async Task<IActionResult> GetDescriptionsByNameAndReportId(int id, string name) {
        var descriptions = 
            await _descriptionService.GetDescriptionsByNameAndReportId(name, id);

        if (descriptions.Result == "Get descriptions by name and report id. Descriptions did not found") 
            return BadRequest("Nothing to found");

        if (descriptions.StatusCode == Domain.Enum.StatusCode.OK) 
            return Ok(descriptions.Data);

        return NoContent();
    }
    
    [HttpGet("get-descriptions")]
    public async Task<IActionResult> GetDescriptions() {
        var descriptions =
            await _descriptionService.GetDescriptions();

        if (descriptions.Result == "Get descriptions. Descriptions did not found") 
            return BadRequest("Nothing to found");

        if (descriptions.StatusCode == Domain.Enum.StatusCode.OK) 
            return Ok(descriptions.Data);

        return NoContent();
    }
}