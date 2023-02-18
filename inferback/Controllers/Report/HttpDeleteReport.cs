using Inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Report; 

[ApiController]
[Route("api/report/[controller]")]
public class HttpDeleteReport : ControllerBase {
    private readonly IReportService _reportService;

    public HttpDeleteReport(IReportService reportService) {
        _reportService = reportService;
    }
    
    [HttpDelete("delete-report/{id}")]
    public async Task<IActionResult> DeleteReport(int id) {
        if (id == null) {
            return BadRequest("Request have to include id");
        }

        var response = await _reportService.DeleteReport(id);

        if (response.StatusCode == Inferback.Domain.Enum.StatusCode.OK) {
            return Ok("Object 'report' delete successfully");
        }

        return BadRequest("Object 'report' did not delete");

    }
}