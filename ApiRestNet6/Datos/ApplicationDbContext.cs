using ApiRestNet6.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNet6.Datos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Villa> villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1, 
                    Nombre = "Villa 1", 
                    Detalle = "Detalla de la Villa", 
                    ImagenUrl = "", 
                    Ocupantes = 5,
                    MetrosCuadrados = 50, 
                    Tarifa = 200, 
                    Amenidad = "", 
                    FechaCreacion = DateTime.Now, 
                    FechaActualizacion = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Villa 2",
                    Detalle = "Villa vista a la Piscina",
                    ImagenUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                });
        }
    }
}
