using Data.Models;
using DTOs.request;
using DTOs.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;

namespace BancoG4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        private readonly IDireccionService _service;
        public DireccionController(IDireccionService direccion)
        {
            _service = direccion;
        }
        [HttpGet]
        public async Task<IEnumerable<DireccionDTOOut>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Direccion?>> GetId(int id)
        {
            var direccion = await _service.GetId(id);
            if (direccion == null)
            {
                return NotFound();
            }
            if(direccion is not null)
            {
                return Ok(direccion);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DireccionDTOIn direccionDTO)
        {
            var direccion = await _service.Create(direccionDTO);
            return CreatedAtAction(nameof(GetId), new { id = direccion.Id }, direccion);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DireccionDTOIn direccionDTO)
        {
            if (id != direccionDTO.Id)
            {
                return BadRequest();
            }
            var existe = await _service.GetId(id);
            if (existe == null)
            {
                return NotFound();
            }
            else
            {
                await _service.Update(id, direccionDTO);
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = _service.GetId(id);
            if ( existe == null)
            {
                return BadRequest();
            }
            if( existe is not null)
            {
                await _service.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
