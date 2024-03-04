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
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaService _service;
        public ProvinciaController(IProvinciaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Provincia>> GetAll()
        {
            return await _service.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Provincia?>> GetId(int id)
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
    public async Task<IActionResult> Create(ProvinciumDTOIn provincia)
    {
        var nuevo = await _service.Create(provincia);
        return CreatedAtAction(nameof(GetId), new { id = provincia.Id }, nuevo);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProvinciumDTOIn provinciumDTOIn)
    {
        var existe = await GetId(id);
        if (existe is not null)
        {
            await _service.Update(id, provinciumDTOIn);
            return NoContent();
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
            return NoContent();
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

