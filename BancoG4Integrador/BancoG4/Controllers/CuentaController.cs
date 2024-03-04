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
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }
        [HttpGet]
        public async Task<IEnumerable<CuentaDTOOut>> GetAll()
        {
            return await _cuentaService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuenta>> GetId(int id)
        {
            var cuenta = await _cuentaService.GetId(id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return Ok(cuenta);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CuentaDTOIn cuentaDTOIn)
        {
            var cuenta = await _cuentaService.Create(cuentaDTOIn);
            return CreatedAtAction(nameof(GetId), new { id = cuenta.Id }, cuenta);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CuentaDTOIn cuentaDTO)
        {
            var existe = await _cuentaService.GetId(id);
            if(existe == null)
            {
                return NotFound();
            }if(existe is not null)
            {
                await _cuentaService.Update(id, cuentaDTO);
                return Ok(existe);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = _cuentaService.GetId(id);
            if (existe == null)
            {
                return NotFound();
            }
            if (existe is not null)
            {
                await _cuentaService.Delete(id);
                return Ok(existe);
            }
            return BadRequest();
        }
    }
}
