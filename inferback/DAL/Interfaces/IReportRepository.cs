using inferback.Domain.Entity;

namespace inferback.DAL.Interfaces;

public interface IReportRepository : IBaseRepository<Report> {
    Task<List<Report>> SelectReportsOfProject(int id);
}