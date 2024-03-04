using Data.Models;
using DTOs.request;
using DTOs.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System.Collections;

namespace BancoG4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _service;
        public PaisController(IPaisService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<PaisDTOOut>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais?>> GetId(int id)
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
        public async Task<IActionResult> Create(Pais pais)
        {
            var nuevoPais = await _service.Create(pais);
            return CreatedAtAction(nameof(GetId), new { id = nuevoPais.Id }, nuevoPais);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PaisDTOIn pais)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                await _service.Update(id, pais);
                return Ok(pais);
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
            if ( existe is not null)
            {
                await _service.Delete(id);
                return Ok();
            }
            if(existe == null)
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
