using inferback.DAL.Interfaces;
using inferback.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace inferback.DAL.Repositories;

public class DescriptionRepository : IDescriptionRepository {
    private readonly ApplicationDbContext _db;

    public DescriptionRepository(ApplicationDbContext db) {
        _db = db;
    }

    public async Task<bool> Create(Description entity) {
        await _db.Descriptions.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Description> Get(int id) {
        return (await _db.Descriptions.FirstOrDefaultAsync(x => x.id == id))!;
    }

    public async Task<List<Description>> Select() {
        return await _db.Descriptions.ToListAsync();
    }

    public async Task<List<Description>> SelectDescriptionsOfReport(int id) {
        return await _db.Descriptions.Where(x => x.reportId == id).ToListAsync();
    }
    
    public async Task<List<Description>> SelectByNameAndReportId(string name, int reportId) {
        return await _db.Descriptions.Where
            (x => x.name == name && x.reportId == reportId).ToListAsync();
    }

    public async Task<bool> Delete(Description entity) {
        _db.Descriptions.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Description> Update(Description entity) {
        _db.Descriptions.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}