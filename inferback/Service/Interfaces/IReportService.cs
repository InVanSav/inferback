using inferback.Domain.Entity;
using inferback.Domain.Response;
using inferback.Domain.ViewEntities;
using InferTest;

namespace inferback.Service.Interfaces;

public interface IReportService {
    Task<IBaseResponse<IEnumerable<Report>>> GetReports();

    Task<IBaseResponse<IEnumerable<Report>>> GetReportsOfProject(int id);

    Task<IBaseResponse<Report>> GetReport(int id);

    Task<IBaseResponse<bool>> DeleteReport(int id);

    Task<IBaseResponse<Report>> CreateReport(ReportView entity);

    Task<IBaseResponse<Report>> UpdateReport(ReportView entity);
}