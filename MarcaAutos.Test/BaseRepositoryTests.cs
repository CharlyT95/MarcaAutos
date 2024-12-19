using Moq;
using MarcasAUtosAPI.Domain;
using MarcasAUtosAPI.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Persistence;
using Persistence.Repositories;

namespace MarcasAutosAPI.Tests
{
    public class BaseRepositoryTests
    {
        private readonly DbContextOptions<AutosDbContext> _options;
        private readonly IBaseRepository<MarcaAuto> _repository;

        public BaseRepositoryTests()
        {
            // Configuramos el DbContext para usar la base de datos en memoria
            _options = new DbContextOptionsBuilder<AutosDbContext>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;

            var context = new AutosDbContext(_options);
            _repository = new BaseRepository<MarcaAuto>(context);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllMarcaAutos()
        {
            // Arrange: Preparamos los datos
            var context = new AutosDbContext(_options);
            context.MarcasAutos.Add(new MarcaAuto { Id = 1, Nombre = "Marca 1", Abreviatura ="M1", Descripcion = "Test1", FechaCreacion = DateTime.UtcNow });
            context.MarcasAutos.Add(new MarcaAuto { Id = 2, Nombre = "Marca 2" , Abreviatura = "M2", Descripcion = "Test2", FechaCreacion = DateTime.UtcNow });
            await context.SaveChangesAsync();

            // Act: Ejecutamos el método
            var result = await _repository.GetAllAsync();

            // Assert: Verificamos que el resultado sea el esperado
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }


    }
}
