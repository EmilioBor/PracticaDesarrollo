using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTOs.request;
using DTOs.response;
using Services.Interface;

namespace BancoG4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _context;

        public BancoController(IBancoService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<BancoDtoOut>> Get()
        {   
            return await _context.GetAll();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BancoDtoOut>> GetById(int id)
        {
            var banco = await _context.GetByID(id);
            return banco == null ? NotFound() : Ok(banco);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(BancoDtoIn bancoDtoIn)
        {
            var nueboBanco = await _context.Create(bancoDtoIn);

            return CreatedAtAction(nameof(GetById), new { id = nueboBanco.Id }, nueboBanco);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BancoDtoIn bancoDtoIn)
        {
            var existe = await GetById(id);
            if (existe is not null)
            {
                await _context.Update(id, bancoDtoIn);
                return Ok(bancoDtoIn);
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
            var existe = await GetById(id);
            if (existe is not null)
            {
                await _context.Delete(id);
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
