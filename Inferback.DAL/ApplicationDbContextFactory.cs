using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inferback.DAL; 

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> {
    public ApplicationDbContext CreateDbContext(string[] args) {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        string connection =
            "server=localhost;port=3306;user=inferback;password=inferback;database=inferback";
        
        optionsBuilder.UseMySql(connection,
                                new MariaDbServerVersion(new Version(10, 9, 5)));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}