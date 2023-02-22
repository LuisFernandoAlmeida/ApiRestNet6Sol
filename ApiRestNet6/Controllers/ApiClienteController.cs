using ApiRestNet6.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ApiRestNet6.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ApiClienteController : ControllerBase
    {
        [HttpGet ("GetHolaMundo")]
        public string GetHolaMundo()
        {
            return "Hola Mundo...";
        }
        [HttpGet("GetEntero")]
        public int GetEntero()
        {
            return 5000;
        }
        [HttpGet("GetClaseCliente")]
        public ClienteEN GetClaseCliente()
        {
           var obj=new ClienteEN();
           obj.id = 1;
           obj.Nombre = "Luis";
           return obj;
        }
    }
}
