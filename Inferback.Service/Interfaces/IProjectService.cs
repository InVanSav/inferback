using Inferback.Domain.Entity;
using Inferback.Domain.Response;
using Inferback.Domain.ViewEntities;

namespace Inferback.Service.Interfaces; 

public interface IProjectService {
    Task<IBaseResponse<IEnumerable<Project>>> GetProjects();

    Task<IBaseResponse<Project>> GetProject(int id);

    Task<IBaseResponse<bool>> DeleteProject(int id);

    Task<IBaseResponse<Project>> CreateProject(ProjectView entity);

    Task<IBaseResponse<Project>> UpdateProject(ProjectView entity);
}