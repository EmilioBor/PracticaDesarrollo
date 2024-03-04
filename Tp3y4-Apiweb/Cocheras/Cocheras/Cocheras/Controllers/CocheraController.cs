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
    public class CocheraController : ControllerBase
    {
        private readonly ICocheraService _service;
        public CocheraController(ICocheraService service)
        {
            _service = service;
        }
        [HttpGet("listar")]
        public async Task<IEnumerable<CocheraDtoOut>> GetAll()
        {
            return await _service.GetAll();
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CocheraDtoOut?>> GetById(int id)
        //{
        //    return await _service.GetById(id);
        //}
        [HttpGet("/buscarPorID/{id}")]
        public async Task<ActionResult<Cocheras?>> GetId(int id)
        {
            return await _service.GetId(id);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CocheraDtoIn cocheras)
        {
            var nuevoCocheras = await _service.Create(cocheras);

            return CreatedAtAction(nameof(GetId), new { id = nuevoCocheras.Id }, nuevoCocheras);
        }
        [HttpPut("/update/{id}")]
        public async Task<IActionResult> Update(int id, CocheraDtoIn cocheras)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                await _service.Update(id, cocheras);
                return Ok();
            }

            return BadRequest();
        }
        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                await _service.Delete(id);
                return Ok();
            }

            return BadRequest();
        }
    }
}
