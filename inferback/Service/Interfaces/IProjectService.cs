using inferback.Domain.Entity;
using inferback.Domain.Response;
using inferback.Domain.ViewEntities;

namespace inferback.Service.Interfaces; 

public interface IProjectService {
    Task<IBaseResponse<IEnumerable<Project>>> GetProjects();

    Task<IBaseResponse<Project>> GetProject(int id);

    Task<IBaseResponse<bool>> DeleteProject(int id);

    Task<IBaseResponse<Project>> CreateProject(ProjectView entity);

    Task<IBaseResponse<Project>> UpdateProject(ProjectView entity);
}