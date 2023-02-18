using Inferback.DAL.Interfaces;
using Inferback.Domain.Entity;
using Inferback.Domain.Enum;
using Inferback.Domain.Response;
using Inferback.Service.Interfaces;

namespace Inferback.Service.Implementations; 

public class ProjectService : IProjectService {
    private readonly IProjectRepository _projectRepository;
    
    public ProjectService(IProjectRepository projectRepository) {
        _projectRepository = projectRepository;
    }

    public async Task<IBaseResponse<Project>> GetProject(int id) {
        var baseResponse = new BaseResponse<Project>();

        try {
            var project = await _projectRepository.Get(id);
            
            if (project == null) {
                baseResponse.Result = "Get project. Project did not found";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = project;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {
            return new BaseResponse<Project>() {
                Result = $"[GetProject] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<Project>>> GetProjects() {
        var baseResponse = new BaseResponse<IEnumerable<Project>>();

        try {
            var projects = await _projectRepository.Select();

            if (projects == null) {
                baseResponse.Result = "Get projects. Projects did not found";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = projects;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
            
        } catch (Exception ex) {
            return new BaseResponse<IEnumerable<Project>>() {
                Result = $"[GetProjects] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProject(int id) {
        var baseResponse = new BaseResponse<bool>();

        try {
            var project = await _projectRepository.Get(id);

            if (project == null) {
                baseResponse.Result = "Project does not exist";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            await _projectRepository.Delete(project);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {
            return new BaseResponse<bool>() {
                Result = $"[DeleteProject] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
    
    public async Task<IBaseResponse<Project>> CreateProject(Project entity) {
        var baseResponse = new BaseResponse<Project>();

        try {
            var project = new Project() {
                id = entity.id,
                name = entity.name,
                path = entity.path,
                createdAt = entity.createdAt,
            };

            if (project == null) {
                baseResponse.Result = "Project did not add";
                baseResponse.StatusCode = StatusCode.DataDidNotAdd;
                return baseResponse;
            }

            await _projectRepository.Create(project);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {
            return new BaseResponse<Project>() {
                Result = $"[CreateProject] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
    
    public async Task<IBaseResponse<Project>> UpdateProject(int id, Project entity) {
        var baseResponse = new BaseResponse<Project>();

        try {
            var project = await _projectRepository.Get(id);

            if (project == null) {
                baseResponse.StatusCode = StatusCode.DataNotFound;
                baseResponse.Result = "Project did not found";
                return baseResponse;
            }

            project.id = entity.id;
            project.name = entity.name;
            project.path = entity.path;
            project.createdAt = entity.createdAt;

            await _projectRepository.Update(project);
            return baseResponse;

        } catch (Exception ex) {
            return new BaseResponse<Project>() {
                Result = $"[UpdateProject] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
}