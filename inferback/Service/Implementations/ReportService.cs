using inferback.DAL.Interfaces;
using inferback.Domain.Entity;
using inferback.Domain.Enum;
using inferback.Domain.Response;
using inferback.Domain.ViewEntities;
using inferback.Service.Interfaces;

namespace inferback.Service.Implementations;

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
    
    public async Task<IBaseResponse<Report>> CreateReport(ReportView entity) {
        var baseResponse = new BaseResponse<Report>();

        try {
            var report = new Report() {
                name = entity.name,
                bugsCount = entity.bugsCount,
                projectId = entity.projectId,
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
    
    public async Task<IBaseResponse<Report>> UpdateReport(ReportView entity) {
        var baseResponse = new BaseResponse<Report>();

        try {
            var report = await _reportRepository.Get(entity.id);

            if (report == null) {
                baseResponse.StatusCode = StatusCode.DataNotFound;
                baseResponse.Result = "Report did not found";
                return baseResponse;
            }

            report.name = entity.name;
            report.bugsCount = entity.bugsCount;
            report.projectId = entity.projectId;

            await _reportRepository.Update(report);

            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;

        } catch (Exception ex) {
            return new BaseResponse<Report>() {
                Result = $"[UpdateReport] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
}