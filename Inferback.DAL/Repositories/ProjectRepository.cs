using Inferback.DAL.Interfaces;
using Inferback.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inferback.DAL.Repositories; 

public class ProjectRepository : IProjectRepository {
    private readonly ApplicationDbContext _db;
    
    public ProjectRepository(ApplicationDbContext db) {
        _db = db;
    }

    public async Task<bool> Create(Project entity) {
        await _db.Projects.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;    }

    public async Task<Project> Get(int id) {
        return await _db.Projects.FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<List<Project>> Select() {
        return await _db.Projects.ToListAsync();
    }

    public async Task<bool> Delete(Project entity) {
        _db.Projects.Remove(entity);
        await _db.SaveChangesAsync();

        return true;    }
}