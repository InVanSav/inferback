using inferback.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inferback.Controllers.Report; 

[ApiController]
[Route("api/report/[controller]")]
public class HttpGetReport : ControllerBase {
    private readonly IReportService _reportService;

    public HttpGetReport(IReportService reportService) {
        _reportService = reportService;
    }

    [HttpGet("get-reports")]
    public async Task<IActionResult> GetReports() {
        var response = await _reportService.GetReports();

        if (response.Result == "Get reports. Reports did not found") {
            return BadRequest("Nothing to found");
        }

        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return Ok(response.Data);
        }

        return NoContent();
    }

    [HttpGet("get-report/{id}")]
    public async Task<IActionResult> GetReport(int id) {
        var response = await _reportService.GetReport(id);

        if (response.Result == "Get report. Report did not found") {
            return BadRequest("Nothing to found");
        }

        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return Ok(response.Data);
        }

        return NoContent();
    }
}