using Inferback.Domain.ViewEntities;
using Inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Report; 

[ApiController]
[Route("api/report/[controller]")]
public class HttpPostReport : ControllerBase {
    private readonly IReportService _reportService;
    
    public HttpPostReport(IReportService reportService) {
        _reportService = reportService;
    }
    
    [HttpPost("create-report")]
    public async Task<IActionResult> CreateReport([FromBody] ReportView entity) {
        if (entity == null) {
            return BadRequest("Request have to include entity");
        }

        var response = await _reportService.CreateReport(entity);

        if (response.StatusCode == Inferback.Domain.Enum.StatusCode.OK) {
            return Ok(response.Data);
        }

        return NoContent();
    }
}