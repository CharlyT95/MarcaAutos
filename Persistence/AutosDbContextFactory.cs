using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence
{
    public class AutosDbContextFactory : IDesignTimeDbContextFactory<AutosDbContext>
    {
        public AutosDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AutosDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Autos;Username=postgres;Password=123456");

            return new AutosDbContext(optionsBuilder.Options);
        }
    }
}
