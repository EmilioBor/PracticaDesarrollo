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
    public class TipoTransaccionController : ControllerBase
    {
        private readonly ITipoTransaccionService _service;
        public TipoTransaccionController(ITipoTransaccionService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<TipoTransaccionDTOOut>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTransaccion?>> GetId(int id)
        {
            var existe = await _service.GetxId(id);
            if (existe is not null)
            {
                return Ok(existe);
            }
            if (existe is null)
            {
                return BadRequest();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(TipoTransaccionDTOIn tipoTransaccion)
        {
            var nuevo = await _service.Create(tipoTransaccion);
            return CreatedAtAction(nameof(GetId), new { id = tipoTransaccion.Id }, nuevo);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TipoTransaccionDTOIn tipoTransaccion)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                await _service.Update(id, tipoTransaccion);
                return Ok(tipoTransaccion);
            }
            if (existe == null)
            {
                return BadRequest();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                await _service.Delete(id);
                return Ok();
            }
            if (existe == null)
            {
                return BadRequest();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
