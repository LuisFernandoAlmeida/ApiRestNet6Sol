using ApiRestNet6.Datos;
using ApiRestNet6.Modelos;
using ApiRestNet6.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestNet6.Controllers
{
    [Route("api/Villa")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger <VillaController> _logger;

        public VillaController(ILogger<VillaController>logger)
        {
            _logger = logger; 
        }

        
        [HttpGet("GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Villa>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas");
            return Ok(new List<Villa> 
            { new Villa { Id = 1, Nombre = "Vista a la piscina", FechaCreacion = DateTime.Now }, 
              new Villa { Id = 2, Nombre = "Vista a la playa", FechaCreacion = DateTime.Now } 
            });
        }
        
        [HttpGet("GetVillasDto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult <IEnumerable<VillaDto>> GetVillasDto()
        {
            return Ok (new List<VillaDto>
            {
                new VillaDto{Id=1,Nombre="Vista a la piscina"},
                new VillaDto{Id=2,Nombre="Vista a la playa"}
            });
        }
        
        [HttpGet("GetVillasStore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult <IEnumerable<VillaDto>> GetVillasStore()
        {
            return Ok(VillaStore.villaList);
        }
        
        [HttpGet("GetVillaStore id int", Name ="GetVillaId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult <VillaDto> GetVillaStore(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer el id" + id); 
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();

            }
            return Ok(villa); 
        }
        [HttpPost ("CrearVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villaDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            if (VillaStore.villaList.FirstOrDefault(v=>v.Nombre.ToLower()==villaDto.Nombre.ToLower())!=null) 
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
            villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDto);
            return CreatedAtRoute("GetVillaId", new { id = villaDto.Id},villaDto);
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
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();

            }
            VillaStore.villaList.Remove(villa);
            return NoContent(); 
        }
        [HttpPut ("id int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, VillaDto villaDto)
        {
            if (villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();

            }
            villa.Nombre = villaDto.Nombre;
            villa.Ocupantes = villaDto.Ocupantes;
            villa.MetrosCuadrados = villaDto.MetrosCuadrados; 
            return NoContent();
        }
    }
}
