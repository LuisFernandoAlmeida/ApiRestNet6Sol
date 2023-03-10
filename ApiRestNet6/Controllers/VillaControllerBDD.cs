using ApiRestNet6.Datos;
using ApiRestNet6.Modelos;
using ApiRestNet6.Modelos.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaControllerBDD : ControllerBase
    {
        private readonly ILogger<VillaControllerBDD> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VillaControllerBDD(ILogger<VillaControllerBDD> logger,ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("GetVillasBDD")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task <ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas");
            IEnumerable<Villa> villaList = await _db.villas.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<VillaDto>>(villaList)); 
        }
        [HttpGet("GetVillaStore id int", Name = "GetVillaIdBDD")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDto>> GetVillaStore(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer el id" + id);
                return BadRequest();
            }
            var villa = await _db.villas.FirstOrDefaultAsync(v => v.Id == id);         
            if (villa == null)
            {
                return NotFound();

            }
            return Ok(_mapper.Map<VillaDto>(villa));
        }
        [HttpPost("CrearVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDto>> CrearVilla([FromBody] VillaCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _db.villas.FirstOrDefaultAsync(v => v.Nombre.ToLower() == createDto.Nombre.ToLower())!=null)
            {
                ModelState.AddModelError("ErrorNombre", "Ya existe un nombre repetido");
                return BadRequest(ModelState);
            }

            Villa modelo = _mapper.Map<Villa>(createDto); 

             await _db.villas.AddAsync(modelo);
             await _db.SaveChangesAsync();
            return CreatedAtRoute("GetVillaIdBDD", new { id = modelo.Id }, modelo);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.villas.FirstOrDefaultAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();

            }
            _db.villas.Remove(villa);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("id int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <IActionResult> UpdateVilla(int id, VillaUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.Id)
            {
                return BadRequest();
            }

            Villa modelo = _mapper.Map<Villa>(updateDto);

            _db.Update(modelo);
            await _db.SaveChangesAsync(); 
            return NoContent();
        }
    }
}
