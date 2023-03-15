using ApiRestNet6.Datos;
using ApiRestNet6.Modelos;

namespace ApiRestNet6.Repositorio
{
    public class VilaRepositorio : Repositorio<Villa>, IVillaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public VilaRepositorio(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }
        public async Task<Villa> Actualizar(Villa entidad)
        {
            entidad.FechaActualizacion = DateTime.Now;
            _db.villas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}
