using Data.Models;
using DTOs.request;
using DTOs.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace BancoG4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadService _service;
        public LocalidadController(ILocalidadService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<LocalidadDTOOut>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Localidad?>> GetID(int id)
        {
            var localidad = await _service.GetID(id);
            if(localidad is not null)
            {
                return Ok(localidad);
            }
            if (localidad is null)
            {
                return BadRequest();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(LocalidadDTOIn localidad)
        {
            var nuevo = await _service.Create(localidad);

            return CreatedAtAction(nameof(GetID), new { id = nuevo.Id }, nuevo);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,  LocalidadDTOIn localidad)
        {
            var existe = await GetID(id);
            if (existe is not null)
            {
                await _service.Update(id, localidad);
                return NoContent();
            }
            if(existe is null)
            {
                return BadRequest();
            }
            else { return NotFound(); }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = GetID(id);
            if (existe is not null)
            {
                await _service.Delete(id);
                return Ok();
            }if(existe is null)
            {
                return BadRequest();
            }else
            { return NotFound(); }
        }
    }
}

