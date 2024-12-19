//using MarcasAUtosAPI.Domain;
//using Microsoft.Extensions.Logging;

//namespace Persistence.Persistence
//{
//    public class AutosContextSeed
//    {
//        private readonly AutosDbContext _context;
//        private readonly ILogger<AutosDbContext> _logger;

//        public AutosContextSeed(AutosDbContext context, ILogger<AutosDbContext> logger)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        public async Task SeddAsync()
//        {
//            await _context.Database.EnsureCreatedAsync();

//            if (!_context.MarcasAutos!.Any())
//            {
//                _context.MarcasAutos!.AddRange(GetPreconfiguredAutos());
//                await _context.SaveChangesAsync();
//                _logger.LogInformation("Registrando Clientes DB {_context}", typeof(AutosDbContext).Name);
//            }
//        }

//        private static IEnumerable<MarcaAuto> GetPreconfiguredAutos()
//        {
//            return new List<MarcaAuto>
//            {
//                new MarcaAuto { Nombre = "Hyundai", Abreviatura = "Hyu", Descripcion = "Hyundai Motor Company fabricante Surcoreano" },
//                new MarcaAuto { Nombre = "Nissan", Abreviatura = "Nis", Descripcion = "Nissan fabricante Japones" },
//                new MarcaAuto { Nombre = "Toyota", Abreviatura = "Toy", Descripcion = "Marca Toyota se fabrica en muchos lugares del mundo" },
//                new MarcaAuto { Nombre = "KIA", Abreviatura = "Kia", Descripcion = "Kia Motors  fabricante Surcoreano" }
//            };
//        }
//    }
//}
