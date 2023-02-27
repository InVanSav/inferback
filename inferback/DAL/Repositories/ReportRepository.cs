using inferback.DAL.Interfaces;
using inferback.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace inferback.DAL.Repositories;

public class ReportRepository : IReportRepository {
    private readonly ApplicationDbContext _db;

    public ReportRepository(ApplicationDbContext db) {
        _db = db;
    }

    public async Task<bool> Create(Report entity) {
        await _db.Reports.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Report> Get(int id) {
        return (await _db.Reports.FirstOrDefaultAsync(x => x.id == id))!;
    }

    public async Task<List<Report>> Select() {
        return await _db.Reports.ToListAsync();
    }

    public async Task<List<Report>> SelectReportsOfProject(int id) {
        return await _db.Reports.Where(x => x.projectId == id).ToListAsync();
    }

    public async Task<bool> Delete(Report entity) {
        _db.Reports.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Report> Update(Report entity) {
        _db.Reports.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}