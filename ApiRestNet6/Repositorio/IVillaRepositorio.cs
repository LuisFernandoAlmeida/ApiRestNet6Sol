using ApiRestNet6.Modelos;
namespace ApiRestNet6.Repositorio
{
    public interface IVillaRepositorio: IRepositorio<Villa>    
    {
        Task<Villa> Actualizar(Villa entidad);
    }
}
