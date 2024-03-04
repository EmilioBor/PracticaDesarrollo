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
    public class ClienteXCuentaController : ControllerBase
    {
        private readonly IClienteXCuentaService _service;
        public ClienteXCuentaController(IClienteXCuentaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<ClienteXCuentaDTOOut>> GetAll()
        {
            return await _service.GetAll();
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ClienteXCuentaDTOOut?>> GetIdDTO(int id)
        //{
        //    var existe = await _service.GetId(id);
        //    if ( existe == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(existe);
        //    }
        //}
        [HttpPost(Name ="CreandoClientexCuenta")]
        public async Task<IActionResult> Create(ClienteXCuentaDTOIn clienteXCuentaDTO)
        {
            var nuevoclienteXCuentaDTO = await _service.Create(clienteXCuentaDTO);

            return CreatedAtAction(nameof(GetId), new { id = nuevoclienteXCuentaDTO.Id }, nuevoclienteXCuentaDTO);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizando(int id, ClienteXCuentaDTOIn clienteXCuentaDTO)
        {
            var existe = await _service.GetId(id);
            if( existe == null)
            {
                return NotFound();
            }
            if( existe is not null)
            {
                await _service.Actualizando(id, clienteXCuentaDTO);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminando(int id)
        {
            var existe = await _service.GetId(id);
            if ( existe is not null)
            {
                await _service.Eliminando(id);
                return Ok(existe);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteXcuenta?>> GetId(int id)
        {
            var existe = await _service.GetId(id);

            if (existe is null) { 
                return NotFound(); 
            }
            else
            {
                return existe;
            }
        }
    }
}
