using ApiRestNet6.Modelos;
namespace ApiRestNet6.Repositorio
{
    public interface INumeroVillaRepositorio: IRepositorio<NumeroVilla>    
    {
        Task<NumeroVilla> Actualizar(NumeroVilla entidad);
    }
}
