using ApiRestNet6.Datos;
using ApiRestNet6.Modelos;
using ApiRestNet6.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaControllerBDD : ControllerBase
    {
        private readonly ILogger<VillaControllerBDD> _logger;
        private readonly ApplicationDbContext _db;

        public VillaControllerBDD(ILogger<VillaControllerBDD> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("GetVillasBDD")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Villa>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas");
            return Ok(_db.villas.ToList()); 
        }

        [HttpGet("GetVillaStore id int", Name = "GetVillaIdBDD")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVillaStore(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer el id" + id);
                return BadRequest();
            }
            var villa = _db.villas.FirstOrDefault(v => v.Id == id);         
            if (villa == null)
            {
                return NotFound();

            }
            return Ok(villa);
        }
        [HttpPost("CrearVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_db.villas.FirstOrDefault(v => v.Nombre.ToLower() == villaDto.Nombre.ToLower())!=null)
            {
                ModelState.AddModelError("ErrorNombre", "Ya existe un nombre repetido");
                return BadRequest(ModelState);
            }
            if (villaDto.Id == null)
            {
                return BadRequest(villaDto.Id);
            }
            if (villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Villa modelo = new()
            {
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Nombre,
                ImagenUrl = villaDto.ImagenUrl,
                Ocupantes = villaDto.Ocupantes,
                MetrosCuadrados = villaDto.MetrosCuadrados,
                Tarifa = villaDto.Tarifa,
                Amenidad = villaDto.Amenidad,
            };
            _db.villas.Add(modelo);
            _db.SaveChanges();
            return CreatedAtRoute("GetVillaId", new { id = villaDto.Id }, villaDto);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.villas.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();

            }
            _db.villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPut("id int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, VillaDto villaDto)
        {
            if (villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }

            Villa modelo = new()
            {
                Id=villaDto.Id,
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Nombre,
                ImagenUrl = villaDto.ImagenUrl,
                Ocupantes = villaDto.Ocupantes,
                MetrosCuadrados = villaDto.MetrosCuadrados,
                Tarifa = villaDto.Tarifa,
                Amenidad = villaDto.Amenidad,
            };
            _db.Update(modelo);
            _db.SaveChanges(); 
            return NoContent();
        }
    }
}
