using Inferback.Domain.Entity;
using Inferback.Domain.Response;
using Inferback.Domain.ViewEntities;

namespace Inferback.Service.Interfaces; 

public interface IReportService {
    Task<IBaseResponse<IEnumerable<Report>>> GetReports();
    
    Task<IBaseResponse<Report>> GetReport(int id);

    Task<IBaseResponse<bool>> DeleteReport(int id);

    Task<IBaseResponse<Report>> CreateReport(ReportView entity);

    Task<IBaseResponse<Report>> UpdateReport(ReportView entity);
}