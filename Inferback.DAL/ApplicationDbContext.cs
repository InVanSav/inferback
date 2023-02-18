using Inferback.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inferback.DAL; 

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Project> Projects { get; set; }
    
    public DbSet<Report> Reports { get; set; }
}