using MarcasAUtosAPI.Application.Contracts;
using MarcasAUtosAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Data;

namespace Persistence
{
    public sealed class AutosDbContext(DbContextOptions<AutosDbContext> options) : DbContext(options), IApplicationDbContext
    {

        public IDbConnection Connection => Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            new DbInitializer(modelBuilder).Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<MarcaAuto>? MarcasAutos { get; set; }

        // Métodos de la interfaz
        public DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
