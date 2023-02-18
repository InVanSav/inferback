using Inferback.DAL.Interfaces;
using Inferback.Domain.Entity;
using Inferback.Domain.Enum;
using Inferback.Domain.Response;
using Inferback.Service.Interfaces;

namespace Inferback.Service.Implementations;

public class ReportService : IReportService {
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository reportRepository) {
        _reportRepository = reportRepository;
    }

    public async Task<IBaseResponse<Report>> GetReport(int id) {
        var baseResponse = new BaseResponse<Report>();

        try {
            var report = await _reportRepository.Get(id);

            if (report == null) {
                baseResponse.Result = "Get report. Report did not found";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = report;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex) {
            return new BaseResponse<Report>() {
                Result = $"[GetReport] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<Report>>> GetReports() {
        var baseResponse = new BaseResponse<IEnumerable<Report>>();

        try {
            var reports = await _reportRepository.Select();

            if (reports == null) {
                baseResponse.Result = "Get reports. Reports did not found";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = reports;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex) {
            return new BaseResponse<IEnumerable<Report>>() {
                Result = $"[GetReports] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
    
    public async Task<IBaseResponse<bool>> DeleteReport(int id) {
        var baseResponse = new BaseResponse<bool>();

        try {
            var report = await _reportRepository.Get(id);

            if (report == null) {
                baseResponse.Result = "Report does not exist";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            await _reportRepository.Delete(report);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {
            return new BaseResponse<bool>() {
                Result = $"[DeleteReport] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
    
    public async Task<IBaseResponse<Report>> CreateReport(Report entity) {
        var baseResponse = new BaseResponse<Report>();

        try {
            var report = new Report() {
                id = entity.id,
                name = entity.name,
                bugsCount = entity.bugsCount,
                createdAt = entity.createdAt,
            };

            if (report == null) {
                baseResponse.Result = "Report did not add";
                baseResponse.StatusCode = StatusCode.DataDidNotAdd;
                return baseResponse;
            }

            await _reportRepository.Create(report);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {
            return new BaseResponse<Report>() {
                Result = $"[CreateReport] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
    
    public async Task<IBaseResponse<Report>> UpdateReport(int id, Report entity) {
        var baseResponse = new BaseResponse<Report>();

        try {
            var report = await _reportRepository.Get(id);

            if (report == null) {
                baseResponse.StatusCode = StatusCode.DataNotFound;
                baseResponse.Result = "Report did not found";
                return baseResponse;
            }

            report.id = entity.id;
            report.name = entity.name;
            report.bugsCount = entity.bugsCount;
            report.createdAt = entity.createdAt;

            await _reportRepository.Update(report);
            return baseResponse;

        } catch (Exception ex) {
            return new BaseResponse<Report>() {
                Result = $"[UpdateReport] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
}