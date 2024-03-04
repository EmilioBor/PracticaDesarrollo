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
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccionesService _service;
        public TransaccionController(ITransaccionesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<TransaccionDTOOut>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaccion?>> GetId(int id)
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
        public async Task<IActionResult> Create(TransaccionDTOIn transaccion)
        {
            var nuevo = await _service.Create(transaccion);
            return CreatedAtAction(nameof(GetId), new { id = transaccion.Id }, nuevo);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TransaccionDTOIn transaccion)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                await _service.Update(id, transaccion);
                return Ok(transaccion);
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
