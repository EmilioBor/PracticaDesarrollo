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
    public class TipoCuentaController : ControllerBase
    {
        private readonly ITipoCuentaService _service;
        public TipoCuentaController(ITipoCuentaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<TipoCuentaDTOOut>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCuentaDTOOut?>> GetId(int id)
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
        public async Task<IActionResult> Create(TipoCuentaDTOIn tipoCuenta)
        {
            var nuevo = await _service.Create(tipoCuenta);
            return CreatedAtAction(nameof(GetId), new { id = tipoCuenta.Id }, nuevo);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TipoCuentaDTOIn tipoCuenta)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                await _service.Update(id, tipoCuenta);
                return Ok(tipoCuenta);
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
