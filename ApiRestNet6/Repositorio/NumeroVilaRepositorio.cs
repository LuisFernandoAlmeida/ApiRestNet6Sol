using ApiRestNet6.Datos;
using ApiRestNet6.Modelos;

namespace ApiRestNet6.Repositorio
{
    public class NumeroVilaRepositorio : Repositorio<NumeroVilla>, INumeroVillaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public NumeroVilaRepositorio(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }
        public async Task<NumeroVilla> Actualizar(NumeroVilla entidad)
        {
            entidad.Actualizacion = DateTime.Now;
            _db.numeroVillas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}
