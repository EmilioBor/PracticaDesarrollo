using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tp4_weapi.Data.Repositories;
using Tp4_webapi.Model;

namespace Tp4_wepapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IAutoRepository : Controller
    {
        private readonly Tp4_weapi.Data.Repositories.IAutoRepository _autoRepository;

        public IAutoRepository(Tp4_weapi.Data.Repositories.IAutoRepository autoRepository)
        {
            _autoRepository = autoRepository;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAutos()
        {
            return Ok(await _autoRepository.GetAllAutos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutoDetalle(int id)
        {
            return Ok(await _autoRepository.GetAutoDetalle(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuto([FromBody]Auto auto)
        {
            if (auto == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _autoRepository.InsertarAuto(auto);
            return Created("creado", creado);
        }
        [HttpPut(Name = "Editar")]
        public async Task<IActionResult> UpdateAuto([FromBody] Auto auto)
        {
            if (auto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _autoRepository.ActAuto(auto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliAuto(int id)
        {
            await _autoRepository.EliAuto(new Auto { Id = id }, id);
            return NoContent();
        }
    }
}
