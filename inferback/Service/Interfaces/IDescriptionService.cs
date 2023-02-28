using inferback.Domain.Entity;
using inferback.Domain.Response;
using InferTest;

namespace inferback.Service.Interfaces;

public interface IDescriptionService {
    Task<IBaseResponse<IEnumerable<Description>>> GetDescriptionsOfReport(int id);

    Task<IBaseResponse<IEnumerable<Description>>> GetDescriptionsByNameAndReportId(string name, int id);

    Task<IBaseResponse<bool>> DeleteDescription(int id);

    Task<IBaseResponse<Description>> CreateDescription(Script script, int id);

    Task<IBaseResponse<IEnumerable<Description>>> GetDescriptions();
}
