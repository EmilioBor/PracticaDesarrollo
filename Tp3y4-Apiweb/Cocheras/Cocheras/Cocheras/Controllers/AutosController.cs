using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Cochera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        private readonly IAutosService _service;
        public AutosController(IAutosService service)
        {
            _service = service;
        }
        [HttpGet("listarAutos")]
        public async Task<IEnumerable<AutosDtoOut>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("buscando/{id}")]
        public async Task<ActionResult<Autos?>> GetById(int id)
        {
            return await _service.GetById(id);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutosDtoOut?>> GetId(int id)
        {
            return await _service.GetId(id);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AutosDtoIn auto)
        {
            var nuevoAuto = await _service.Create(auto);

            return CreatedAtAction(nameof(GetId), new {id = nuevoAuto.Id}, nuevoAuto );
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AutosDtoIn auto)
        {
            var autoE = GetId(id);
            if (autoE != null)
            {
                 await _service.Update(id, auto);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = await GetId(id);
            if (existe != null)
            {
                await _service.Delete(id);
            }

            return BadRequest();
        }
    }
}
