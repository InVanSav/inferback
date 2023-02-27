using inferback.Domain.Entity;

namespace inferback.DAL.Interfaces;

public interface IDescriptionRepository : IBaseRepository<Description> {
    Task<List<Description>> SelectDescriptionsOfReport(int id);
}