using Inferback.Domain.ViewEntities;
using Inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Report; 

[ApiController]
[Route("api/report/[controller]")]
public class HttpPutReport : ControllerBase {
    private readonly IReportService _reportService;
    
    public HttpPutReport(IReportService reportService) {
        _reportService = reportService;
    }
    
    [HttpPut("edit-report")]
    public async Task<IActionResult> EditReport([FromBody] ReportView entity) {
        if (entity == null) {
            return BadRequest("Request have to include entity");
        }

        var response = await _reportService.UpdateReport(entity);

        if (response.StatusCode == Inferback.Domain.Enum.StatusCode.OK) {
            return Ok("Object 'Report' edited successfully");
        }

        return BadRequest("Object 'Report' did not edit");
    }
}