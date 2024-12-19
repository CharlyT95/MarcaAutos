using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcasAUtosAPI.Domain
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<MarcaAuto>().HasData(
                DatosIniciales()
            );
        }


        public List<MarcaAuto> DatosIniciales()
        {
            var marcas = new List<MarcaAuto>
            {
                new MarcaAuto {Id=1, Nombre = "Hyundai", Abreviatura = "Hyu", Descripcion = "Hyundai Motor Company fabricante Surcoreano" },
                new MarcaAuto {Id=2, Nombre = "Nissan", Abreviatura = "Nis", Descripcion = "Nissan fabricante Japones" },
                new MarcaAuto {Id=3, Nombre = "Toyota", Abreviatura = "Toy", Descripcion = "Marca Toyota se fabrica en muchos lugares del mundo" },
                new MarcaAuto {Id=4, Nombre = "KIA", Abreviatura = "Kia", Descripcion = "Kia Motors  fabricante Surcoreano" }
            };

            return marcas;
        }
    }
}
